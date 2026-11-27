DROP DATABASE IF EXISTS biblioteca;
CREATE DATABASE biblioteca CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE biblioteca;

-- ==========================================================
-- 1. TABLA LIBRO (Incluye Punto B: Código de barras UNIQUE)
-- ==========================================================
CREATE TABLE libro (
    isbn            VARCHAR(20) PRIMARY KEY,
    codigo_barras   VARCHAR(50) NOT NULL UNIQUE,
    nombre          VARCHAR(100) NOT NULL,
    autor           VARCHAR(100) NOT NULL,
    categoria       VARCHAR(50) NOT NULL,
    disponibilidad  INT NOT NULL DEFAULT 0,
    CONSTRAINT chk_disponibilidad CHECK (disponibilidad >= 0)
);

-- ==========================================================
-- 2. TABLA LECTOR (Tu tabla 'usuario' original: alumnos/clientes)
-- ==========================================================
CREATE TABLE lector (
    idLector        INT PRIMARY KEY AUTO_INCREMENT,
    nombre          VARCHAR(50) NOT NULL,
    apellido        VARCHAR(50) NOT NULL,
    credencial      VARCHAR(20) NOT NULL UNIQUE,
    correo          VARCHAR(100)
);

-- ==========================================================
-- 3. TABLA USUARIOS DEL SISTEMA (Punto C: Login, Hash y Roles)
-- ==========================================================
CREATE TABLE usuarios_sistema (
    idUsuario       INT PRIMARY KEY AUTO_INCREMENT,
    nombre_completo VARCHAR(100) NOT NULL,
    username        VARCHAR(50) NOT NULL UNIQUE,
    password_hash   VARCHAR(255) NOT NULL,
    rol             ENUM('Administrador', 'Bibliotecario', 'Consulta') NOT NULL,
    estado          ENUM('Activo', 'Inactivo') NOT NULL DEFAULT 'Activo'
);

-- ==========================================================
-- 4. TABLA PRESTAMO (Adaptada para controlar devoluciones y retrasos)
-- ==========================================================
CREATE TABLE prestamo (
    idPrestamo          INT PRIMARY KEY AUTO_INCREMENT,
    idLector            INT NOT NULL,
    idUsuarioSistema    INT NOT NULL, -- Bibliotecario que autorizó el préstamo
    fechaPrestamo       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fechaDevolucion     DATE NOT NULL,     -- Fecha límite de entrega
    fechaDevolucionReal DATE NULL,         -- NULL mientras no lo devuelva
    estado              ENUM('Activo', 'Devuelto') NOT NULL DEFAULT 'Activo',
    
    CONSTRAINT fk_prestamo_lector FOREIGN KEY (idLector) REFERENCES lector(idLector),
    CONSTRAINT fk_prestamo_usuario_sis FOREIGN KEY (idUsuarioSistema) REFERENCES usuarios_sistema(idUsuario)
);

-- ==========================================================
-- 5. TABLA DETALLES PRESTAMO
-- ==========================================================
CREATE TABLE detallesPrestamo (
    idDetalle   INT PRIMARY KEY AUTO_INCREMENT,
    idPrestamo  INT NOT NULL,
    isbn        VARCHAR(20) NOT NULL,
    cantidad    INT NOT NULL DEFAULT 1,
    
    CONSTRAINT fk_detalle_prestamo FOREIGN KEY (idPrestamo) REFERENCES prestamo(idPrestamo),
    CONSTRAINT fk_detalle_libro FOREIGN KEY (isbn) REFERENCES libro(isbn),
    CONSTRAINT chk_cantidad_positiva CHECK (cantidad > 0)
);

-- ==========================================================
-- 6. TABLA AUDITORIA (Punto H: Bitácora de cambios)
-- ==========================================================
CREATE TABLE auditoria (
    id_movimiento       INT PRIMARY KEY AUTO_INCREMENT,
    tabla_afectada      VARCHAR(50) NOT NULL,
    tipo_operacion      ENUM('INSERT', 'UPDATE', 'DELETE') NOT NULL,
    fecha_hora          DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    usuario_responsable VARCHAR(50) NOT NULL,
    datos_anteriores    TEXT NULL,
    datos_nuevos        TEXT NULL
);
-- ==========================================================
-- 1. DATOS DE PRUEBA PARA USUARIOS DEL SISTEMA (Dulce
-- ==========================================================
INSERT INTO usuarios_sistema (nombre_completo, username, password_hash, rol, estado) VALUES
('Dulce Lopez', 'administrador', SHA2('clave123', 256), 'Administrador', 'Activo'),
('Iván Orozco', 'bibliotecario', SHA2('clave123', 256), 'Bibliotecario', 'Activo'),
('Miguel Rico', 'consulta_general', SHA2('clave123', 256), 'Consulta', 'Activo'),
('Usuario Bloqueado', 'prueba_inactivo', SHA2('clave123', 256), 'Bibliotecario', 'Inactivo');

-- ==========================================================
-- 2. PROCEDIMIENTO ALMACENADO PARA EL LOGIN
-- ==========================================================
DELIMITER $$
CREATE PROCEDURE iniciar_sesion(
    IN p_username VARCHAR(50),
    IN p_password_hash VARCHAR(255),
    IN p_rol VARCHAR(20)
)
BEGIN
    SELECT idUsuario, nombre_completo, username, rol, estado
    FROM usuarios_sistema
    WHERE username = p_username
      AND password_hash = p_password_hash
      AND rol = p_rol
    LIMIT 1;
END $$

-- ==========================================================
-- 3. TRIGGERS DE AUDITORÍA (Dulce
-- Registran automáticamente cambios en libro y prestamo
-- ==========================================================
CREATE TRIGGER trg_auditoria_libro_update
AFTER UPDATE ON libro
FOR EACH ROW
BEGIN
    IF NOT (OLD.disponibilidad <=> NEW.disponibilidad) 
       OR NOT (OLD.nombre <=> NEW.nombre) 
       OR NOT (OLD.categoria <=> NEW.categoria) THEN
        INSERT INTO auditoria (
            tabla_afectada,
            tipo_operacion,
            fecha_hora,
            usuario_responsable,
            datos_anteriores,
            datos_nuevos
        ) VALUES (
            'libro',
            'UPDATE',
            NOW(),
            IFNULL(@usuario_actual, CURRENT_USER()),
            CONCAT('ISBN: ', OLD.isbn, ' | Título: ', OLD.nombre, ' | Stock: ', OLD.disponibilidad),
            CONCAT('ISBN: ', NEW.isbn, ' | Título: ', NEW.nombre, ' | Stock: ', NEW.disponibilidad)
        );
    END IF;
END $$

-- Trigger 2: Baja o eliminación de un libro del catálogo
CREATE TRIGGER trg_auditoria_libro_delete
AFTER DELETE ON libro
FOR EACH ROW
BEGIN
    INSERT INTO auditoria (
        tabla_afectada,
        tipo_operacion,
        fecha_hora,
        usuario_responsable,
        datos_anteriores,
        datos_nuevos
    ) VALUES (
        'libro',
        'DELETE',
        NOW(),
        IFNULL(@usuario_actual, CURRENT_USER()),
        CONCAT('ISBN: ', OLD.isbn, ' | Código: ', OLD.codigo_barras, ' | Título: ', OLD.nombre, ' | Stock previo: ', OLD.disponibilidad),
        'ELIMINADO DEL CATÁLOGO'
    );
END $$

-- Trigger 3: Cambio de estado en prestamoss
CREATE TRIGGER trg_auditoria_prestamo_update
AFTER UPDATE ON prestamo
FOR EACH ROW
BEGIN
    IF NOT (OLD.estado <=> NEW.estado) THEN
        INSERT INTO auditoria (
            tabla_afectada,
            tipo_operacion,
            fecha_hora,
            usuario_responsable,
            datos_anteriores,
            datos_nuevos
        ) VALUES (
            'prestamo',
            'UPDATE',
            NOW(),
            IFNULL(@usuario_actual, CURRENT_USER()),
            CONCAT('Préstamo #', OLD.idPrestamo, ' | Estado: ', OLD.estado),
            CONCAT('Préstamo #', NEW.idPrestamo, ' | Estado: ', NEW.estado, ' | Devuelto: ', IFNULL(NEW.fechaDevolucionReal, 'N/A'))
        );
    END IF;
END $$
DELIMITER ;
