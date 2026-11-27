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


-- ==========================================================
-- 4. TRIGGERS DE VALIDACIÓN, FUNCIONES Y VISTAS (Migui)
-- ==========================================================

-- Trigger 1: Bloquear préstamo si no hay ejemplares suficientes
DELIMITER $$
CREATE TRIGGER trg_validar_disponibilidad_prestamo
BEFORE INSERT ON detallesPrestamo
FOR EACH ROW
BEGIN
    DECLARE v_disponibilidad INT;

    SELECT disponibilidad INTO v_disponibilidad
    FROM libro
    WHERE isbn = NEW.isbn;

    IF v_disponibilidad IS NULL THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: El libro especificado no existe en el catálogo.';
    ELSEIF NEW.cantidad > v_disponibilidad THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: Disponibilidad insuficiente para realizar el préstamo.';
    END IF;
END $$

DELIMITER ;

-- Trigger 2: Evitar devolver un préstamo que ya fue devuelto
DELIMITER $$
CREATE TRIGGER trg_validar_devolucion_unica
BEFORE UPDATE ON prestamo
FOR EACH ROW
BEGIN
    IF OLD.estado = 'Devuelto' AND NEW.estado = 'Devuelto' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: Este préstamo ya fue marcado como devuelto anteriormente.';
    END IF;
END $$

DELIMITER ;


-- Función 1: Calcular días de retraso de un préstamo
DELIMITER $$
CREATE FUNCTION fn_calcular_dias_retraso(p_idPrestamo INT)
RETURNS INT
READS SQL DATA
BEGIN
    DECLARE v_fecha_limite DATE;
    DECLARE v_fecha_real DATE;
    DECLARE v_estado VARCHAR(20);
    DECLARE v_dias INT DEFAULT 0;

    SELECT fechaDevolucion, fechaDevolucionReal, estado
    INTO v_fecha_limite, v_fecha_real, v_estado
    FROM prestamo
    WHERE idPrestamo = p_idPrestamo;

    IF v_estado = 'Activo' THEN
        SET v_dias = DATEDIFF(CURDATE(), v_fecha_limite);
    ELSEIF v_estado = 'Devuelto' AND v_fecha_real IS NOT NULL THEN
        SET v_dias = DATEDIFF(v_fecha_real, v_fecha_limite);
    END IF;

    IF v_dias < 0 THEN
        SET v_dias = 0;
    END IF;

    RETURN v_dias;
END $$

DELIMITER ;

DELIMITER $$

-- Función 2: Verificar estado de disponibilidad de un libro
CREATE FUNCTION fn_estado_disponibilidad(p_isbn VARCHAR(20))
RETURNS VARCHAR(30)
READS SQL DATA
BEGIN
    DECLARE v_disp INT DEFAULT 0;

    SELECT disponibilidad INTO v_disp
    FROM libro
    WHERE isbn = p_isbn;

    IF v_disp <= 0 THEN
        RETURN 'Agotado';
    ELSEIF v_disp <= 2 THEN
        RETURN 'Últimos ejemplares';
    ELSE
        RETURN 'Disponible';
    END IF;
END $$

DELIMITER ;


-- Reporte 1: Libros más prestados
CREATE VIEW vw_libros_mas_prestados AS
SELECT 
    l.isbn, l.codigo_barras, l.nombre AS titulo, l.autor, l.categoria,
    COUNT(DISTINCT p.idPrestamo) AS veces_solicitado,
    SUM(dp.cantidad) AS total_ejemplares_prestados,
    l.disponibilidad AS stock_actual,
    fn_estado_disponibilidad(l.isbn) AS estatus
FROM libro l
INNER JOIN detallesPrestamo dp ON l.isbn = dp.isbn
INNER JOIN prestamo p ON dp.idPrestamo = p.idPrestamo
GROUP BY l.isbn, l.codigo_barras, l.nombre, l.autor, l.categoria, l.disponibilidad
HAVING SUM(dp.cantidad) >= 1
ORDER BY total_ejemplares_prestados DESC, veces_solicitado DESC;


-- Reporte 2: Lectores con préstamos vencidos / con retraso 
CREATE VIEW vw_prestamos_vencidos AS
SELECT 
    lec.credencial, CONCAT(lec.nombre, ' ', lec.apellido) AS lector, lec.correo,
    p.idPrestamo, p.fechaPrestamo, p.fechaDevolucion AS fecha_limite,
    fn_calcular_dias_retraso(p.idPrestamo) AS dias_retraso,
    GROUP_CONCAT(l.nombre SEPARATOR ', ') AS libros_pendientes
FROM lector lec
INNER JOIN prestamo p ON lec.idLector = p.idLector
INNER JOIN detallesPrestamo dp ON p.idPrestamo = dp.idPrestamo
INNER JOIN libro l ON dp.isbn = l.isbn
WHERE p.estado = 'Activo'
GROUP BY lec.credencial, lec.nombre, lec.apellido, lec.correo, p.idPrestamo, p.fechaPrestamo, p.fechaDevolucion
HAVING dias_retraso > 0
ORDER BY dias_retraso DESC;


-- ==========================================================
-- 5. PROCEDIMIENTOS ALMACENADOS DE PRÉSTAMOS, DEVOLUCIONES Y ESCÁNER (Iván)
-- ==========================================================
DELIMITER $$

-- SP 1: Búsqueda por escáner o teclado (Punto E)
CREATE PROCEDURE sp_buscar_ejemplar_por_codigo(
    IN p_codigo_barras VARCHAR(50)
)
BEGIN
    SELECT 
        isbn,
        codigo_barras,
        nombre AS titulo,
        autor,
        categoria,
        disponibilidad,
        IF(disponibilidad > 0, 'Disponible', 'Sin Stock') AS estado
    FROM libro
    WHERE codigo_barras = p_codigo_barras 
       OR isbn = p_codigo_barras
    LIMIT 1;
END $$

-- SP 2: Consulta con parámetro OUT (Punto E)
CREATE PROCEDURE sp_contar_copias_disponibles(
    IN p_isbn VARCHAR(20),
    OUT p_disponibles INT
)
BEGIN
    SELECT disponibilidad INTO p_disponibles
    FROM libro
    WHERE isbn = p_isbn;
    
    IF p_disponibles IS NULL THEN
        SET p_disponibles = 0;
    END IF;
END $$

-- SP 3: Crear cabecera del préstamo con transacción (Puntos D y E)
CREATE PROCEDURE sp_crear_cabecera_prestamo(
    IN p_id_lector INT,
    IN p_id_usuario_sistema INT,
    IN p_fecha_devolucion DATE,
    IN p_usuario_auditoria VARCHAR(50),
    OUT p_id_prestamo_generado INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        SET p_id_prestamo_generado = -1;
        RESIGNAL;
    END;

    SET @usuario_actual = p_usuario_auditoria;

    START TRANSACTION;
        INSERT INTO prestamo (idLector, idUsuarioSistema, fechaDevolucion, estado)
        VALUES (p_id_lector, p_id_usuario_sistema, p_fecha_devolucion, 'Activo');
        
        SET p_id_prestamo_generado = LAST_INSERT_ID();
    COMMIT;
END $$

-- SP 4: Agregar detalle del préstamo y descontar stock con transacción (Puntos D y E)
CREATE PROCEDURE sp_agregar_detalle_prestamo(
    IN p_id_prestamo INT,
    IN p_codigo_barras VARCHAR(50),
    IN p_cantidad INT,
    IN p_usuario_auditoria VARCHAR(50)
)
BEGIN
    DECLARE v_isbn VARCHAR(20);
    DECLARE v_stock INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    SET @usuario_actual = p_usuario_auditoria;

    START TRANSACTION;
        SELECT isbn, disponibilidad INTO v_isbn, v_stock
        FROM libro
        WHERE codigo_barras = p_codigo_barras
        FOR UPDATE;

        IF v_isbn IS NULL THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El código de barras no existe.';
        END IF;

        IF v_stock < p_cantidad THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No hay suficiente stock disponible para este libro.';
        END IF;

        INSERT INTO detallesPrestamo (idPrestamo, isbn, cantidad)
        VALUES (p_id_prestamo, v_isbn, p_cantidad);

        UPDATE libro 
        SET disponibilidad = disponibilidad - p_cantidad
        WHERE isbn = v_isbn;
    COMMIT;
END $$

-- SP 5: Registrar devolución y restaurar stock con transacción (Puntos D y E)
CREATE PROCEDURE sp_registrar_devolucion(
    IN p_id_prestamo INT,
    IN p_usuario_auditoria VARCHAR(50)
)
BEGIN
    DECLARE v_estado VARCHAR(20);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    SET @usuario_actual = p_usuario_auditoria;

    START TRANSACTION;
        SELECT estado INTO v_estado
        FROM prestamo
        WHERE idPrestamo = p_id_prestamo
        FOR UPDATE;

        IF v_estado IS NULL THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El folio de préstamo no existe.';
        END IF;

        IF v_estado = 'Devuelto' THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Este préstamo ya fue devuelto anteriormente.';
        END IF;

        UPDATE prestamo
        SET estado = 'Devuelto',
            fechaDevolucionReal = CURDATE()
        WHERE idPrestamo = p_id_prestamo;

        UPDATE libro l
        INNER JOIN detallesPrestamo dp ON l.isbn = dp.isbn
        SET l.disponibilidad = l.disponibilidad + dp.cantidad
        WHERE dp.idPrestamo = p_id_prestamo;
    COMMIT;
END $$
DELIMITER ;


-- ==========================================================
-- 6. DATOS DE PRUEBA PARA LIBROS Y LECTORES (Iván)
-- ==========================================================
INSERT INTO libro (isbn, codigo_barras, nombre, autor, categoria, disponibilidad) VALUES
('978-6073154604', '7501001001', 'Cien años de soledad', 'Gabriel García Márquez', 'Novela', 3),
('978-8498387087', '7501001002', 'El Principito', 'Antoine de Saint-Exupéry', 'Fábula', 5),
('978-6070728792', '7501001003', 'Clean Code', 'Robert C. Martin', 'Programación', 1);

INSERT INTO lector (nombre, apellido, credencial, correo) VALUES
('Carlos', 'Méndez', 'ALU-2026-01', 'carlos@itsur.edu.mx'),
('Ana', 'Torres', 'ALU-2026-02', 'ana@itsur.edu.mx');