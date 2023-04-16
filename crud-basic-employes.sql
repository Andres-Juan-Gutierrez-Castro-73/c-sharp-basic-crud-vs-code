CREATE DATABASE crud_basic_employes
USE crud_basic_employes

--CREAMOS LA TABLA USARIOS
CREATE TABLE Usuarios(
	Id_Usuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(50),
	Edad INT
)

--CREAMOS LOS PROCEDIMEINTOS ALMACENADOS DE LAS FUNCIONALIDADES DEL CRUD
CREATE PROCEDURE sp_obtener_usuarios
AS BEGIN
SELECT * FROM Usuarios
END

CREATE PROCEDURE sp_obtener_usuario
@Id_Usuario INT
AS BEGIN
SELECT * FROM Usuarios WHERE Id_Usuario = @Id_Usuario
END

CREATE PROCEDURE sp_insertar_usuario
@Nombre VARCHAR(50),
@Edad INT
AS BEGIN
INSERT INTO Usuarios VALUES(@Nombre, @Edad)
END

CREATE PROCEDURE sp_actualizar_usuario
@Id_Usuario INT,
@Nombre VARCHAR(50),
@Edad INT
AS BEGIN
UPDATE Usuarios SET Nombre=@Nombre, Edad=@Edad WHERE Id_Usuario=@Id_Usuario
END

CREATE PROCEDURE sp_eliminar_usuario
@Id_Usuario INT
AS BEGIN
DELETE Usuarios WHERE Id_Usuario = @Id_Usuario
END