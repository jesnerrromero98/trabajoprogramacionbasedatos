create database bd_ger
go
use bd_ger
go

create table Usuarios(
idusuario int primary key identity(1,1),
cedula varchar(14),
nombres varchar(50),
apellidos varchar(50),
email varchar(80),
telefono varchar(10)
CONSTRAINT Usuario_Cedula UNIQUE (cedula, email, telefono));

create table Cuentas(
idcuenta int primary key identity (1,1),
nombreuser varchar(30),
clave varchar(30),
rol varchar(30),
idusuario int,
foreign key (idusuario) references Usuarios (idusuario),
CONsTRAINT NombreUser_Clave UNIQUE (clave, nombreuser));

create table Recursos(
idrecursos int primary key identity (1,1),
nombres varchar(50),
codigo varchar(50),
descripcion varchar(50),
CONSTRAINT NombreRecurso_Codigo UNIQUE (nombres, codigo)
);

create table Solicitud(
idsolicitud int primary key identity (1,1),
aula varchar(10),
nivel varchar (4),
fechasolicitud datetime DEFAULT GETDATE(),
fechauso date,
horainicio time,
horafinal time,
carrera varchar(max),
asignatura varchar(max),
idrecursos int, 
idusuario int,
foreign key (idrecursos) references Recursos (idrecursos),
foreign key (idusuario) references Usuarios (idusuario),
CONSTRAINT Nivel CHECK (nivel= 'I' OR nivel='II' OR nivel= 'III' OR nivel='IV' OR nivel='V')
);

create table Comentarios(
idcomentario int primary key identity(1,1),
nombres varchar(50) NOT NULL,
correo varchar(80) NOT NULL,
telefono varchar(10) NOT NULL,
mensaje varchar(max) NOT NULL
);

--Procedimiento almcenado--

-- COMENTAR--

CREATE PROCEDURE Comentar
   @b int,@idcomentario int, @nombres varchar(100), @correo varchar(50), @telefono varchar(10), @mensaje varchar(max)

AS 
BEGIN
SET NOCOUNT ON;
IF @b=1
   INSERT INTO Comentarios VALUES (@nombres, @correo, @telefono, @mensaje);
IF @b=2
   DELETE FROM Comentarios WHERE idcomentario=@idcomentario;
IF @b=3
   SELECT * FROM Comentarios
IF @b=4
	UPDATE Comentarios SET nombres=@nombres, correo=@correo, telefono=@telefono, mensaje=@mensaje
	WHERE idcomentario=@idcomentario
IF @b=5
	SELECT*FROM Comentarios
	WHERE nombres LIKE '%'+@nombres+'%'
    
END
GO

CREATE PROCEDURE Solicitudes
 @b int, @idsolicitud int, @aula varchar(10), @nivel varchar(4), @fechasolicitud datetime, @horauso date, @horainicio time,
 @horafinal time, @carrera varchar(max), @asignatura varchar(max), @idrecursos int, @idusuario int

AS 
BEGIN
 SET NOCOUNT ON;

IF @b=1
 INSERT INTO Solicitud VALUES (	@nivel,@aula, @fechasolicitud, @horauso, @horainicio, @horafinal, @carrera, @asignatura, @idrecursos, @idusuario);
IF @b=2
   DELETE FROM Solicitud WHERE idsolicitud=@idsolicitud;
IF @b=3   
   select  r.nombres, s.aula,s.nivel, s.fechasolicitud,
           s.fechauso, s.horainicio,s.horafinal, s.carrera,s.asignatura,u.nombres
   from
        Recursos as r inner join Solicitud as s on r.idrecursos= s.idrecursos inner join 
		 Usuarios as u on s.idusuario=u.idusuario
IF @b=4
	UPDATE Solicitud SET aula=@aula, nivel=@nivel, fechasolicitud=@fechasolicitud, fechauso=@horauso,
	horainicio=@horainicio, horafinal=@horafinal, carrera= @carrera, asignatura=@asignatura
IF @b=5
	SELECT*FROM Solicitud
	WHERE aula LIKE '%'+@aula+'%'

		
END
GO

--RECURSOS--

CREATE PROCEDURE recurso
   @b int,@idrecursos int, @nombre varchar(100), @codigo varchar(50), @descripcion varchar(100)

AS 
BEGIN
SET NOCOUNT ON;
IF @b=1
   INSERT INTO Recursos VALUES (@idrecursos,@nombre, @codigo, @descripcion);
IF @b=2
   DELETE FROM Recursos WHERE idrecursos=@idrecursos;
IF @b=3
   SELECT * FROM Recursos
IF @b=4
   UPDATE Recursos set nombres=@nombre, codigo=@codigo, descripcion=@descripcion where idrecursos=@idrecursos
IF @b=5
 select * from Recursos
   where nombres LIKE '%'+@nombre+'%' 
END
GO

--CUENTA--

CREATE PROCEDURE cuenta
   @b int,@idcuenta int, @nombreuser varchar(100), @clave varchar(30), @rol varchar(30),@idusuario int
AS 
BEGIN
SET NOCOUNT ON;
IF @b=1
   INSERT INTO Cuentas VALUES (@nombreuser, @clave, @rol,@idusuario);
IF @b=2
   DELETE FROM Cuentas WHERE idcuenta=@idcuenta;
IF @b=3
   SELECT * FROM Cuentas
IF @b=4
		UPDATE Cuentas SET nombreuser=@nombreuser, clave=@clave, rol=@rol
		WHERE idcuenta=@idcuenta
IF @b=5
	SELECT*FROM Cuentas
	WHERE nombreuser LIKE '%'+@nombreuser+'%'
END
GO

--USUARIO--

CREATE PROCEDURE Usuario
   @b int,@idusuario int, @cedula varchar(14), @nombres varchar(100), @apellido varchar(50), @email varchar(80), @telefono varchar(10)

AS 
BEGIN
SET NOCOUNT ON;
IF @b=1
   INSERT INTO Usuarios VALUES (@cedula, @nombres, @apellido, @email, @telefono);
IF @b=2
   DELETE FROM Usuarios WHERE idusuario=@idusuario;
IF @b=3
   SELECT * FROM Usuarios
 IF @b=4
	UPDATE Usuarios SET cedula=@cedula, nombres=@nombres, apellidos=@apellido
	WHERE idusuario=@idusuario
IF @b=5
	SELECT*FROM Usuarios
	WHERE nombres LIKE '%'+@nombres+'%'   
END
GO