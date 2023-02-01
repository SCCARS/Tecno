CREATE DATABASE EjerLogin;
USE EjerLogin;

CREATE TABLE Usuario
(nombre_Usuario VARCHAR (25),
contraseņa VARCHAR (25),
rol varchar (20),
);

CREATE PROC Iniciosesion
@nombre_Usuario varchar (25),
@contraseņa varchar (25)
AS
select * from Usuario WHERE
nombre_Usuario=@nombre_Usuario and contraseņa=@contraseņa

SELECT * FROM Usuario;
DROP TABLE Usuario; 

INSERT INTO Usuario(nombre_Usuario, contraseņa, rol)VALUES('Administrador', '123456789', 'Admin');
INSERT INTO Usuario(nombre_Usuario, contraseņa, rol)VALUES('Cliente', '987654321', 'Cliente');
INSERT INTO Usuario(nombre_Usuario, contraseņa, rol)VALUES('Secretaria', '456123', 'Secretaria');

CREATE TABLE Persona
(Id INT PRIMARY KEY not null,
nombre VARCHAR (25),
apellido VARCHAR (25),
edad INT,
telefono INT,
);

INSERT INTO Persona(Id, nombre, apellido, edad, telefono)VALUES(1, 'Alex', 'Galvez', 17, 35251648);

SELECT * FROM Persona;