CREATE DATABASE CURSOSCAPACITANDO
GO
USE CURSOSCAPACITANDO
GO
CREATE TABLE TBLCLIENTE(
CEDULA_CLI VARCHAR(25) PRIMARY KEY NOT NULL,
NOMBRE_CLI VARCHAR(40) NOT NULL,
EDAD_CLI REAL NOT NULL,
TELEFONO_CLI REAL,
CELULAR_CLI REAL NOT NULL,
DIRECCION_CLIENTE VARCHAR(50),
COD_EMPL_CLI VARCHAR (25) NOT NULL
)
GO
CREATE TABLE TBLCURSOS(
CODIGO_CURSO INT  PRIMARY KEY  NOT NULL,
TITULO_CURSO VARCHAR(40) NOT NULL,
NHORAS_CURSO INT NOT NULL
)
GO
CREATE TABLE TBLEMPLEADO(
CODEMPLEADO VARCHAR(25) PRIMARY KEY  NOT NULL,
NRODOC_EMPL VARCHAR(20)  NOT NULL,
NOMBRE_EMPL VARCHAR(40) NOT NULL,
FECHAaNT_EMPL DATETIME NOT NULL,
USUARIO_PROF VARCHAR(35) NOT NULL,
CLAVE_PROFESOR VARCHAR(15) NOT NULL,
)
GO
CREATE TABLE TBLCARGO(
CODIGO_CARGO VARCHAR(25) PRIMARY KEY NOT NULL,
DESCRIPCION_CARGO VARCHAR(40) NOT NULL,
COD_EMPL_CARGO VARCHAR(25) NOT NULL,
)
GO
CREATE TABLE TBLPRERREQUISITO(
COD_PRE int IDENTITY(1111,101) PRIMARY KEY NOT NULL,
DESCRIPCION_PRE VARCHAR(40) NOT NULL,
COD_CURSO_PRE INT  NOT NULL,
COD_EMPL_PRE VARCHAR(25) NOT NULL
)
GO
CREATE TABLE TBLTEMAS(
COD_TEMAS int IDENTITY(100,100) PRIMARY KEY NOT NULL,
DESCRIPCION_TEMAS VARCHAR(4000) NOT NULL,
COD_CURSO_TEMAS INT NOT NULL,
COD_EMPL_TEMAS VARCHAR(25) NOT NULL
)
GO
CREATE TABLE TBLMATRICULA(
COD_MATRI VARCHAR(25) PRIMARY KEY NOT NULL,
FECHA_MATRI DATETIME DEFAULT GETDATE() NOT NULL,
CEDCLIENTE_MATRI VARCHAR(25) NOT NULL,
COD_EMPL_MATRI VARCHAR(25) NOT NULL,
COD_PAGO_MATRI VARCHAR(25) NOT NULL
)
GO
CREATE TABLE TBLDETALLEMATRICULA(
COD_DETALLE INT IDENTITY(0101,0101) PRIMARY KEY NOT NULL,
COD_MATRI_DETA VARCHAR(25) NOT NULL,
DESCRIPCION_DETMATRI VARCHAR(40) NOT NULL,
VALOR_MATRI_DETA REAL NOT NULL,
ID_PROG_DETA INT NOT NULL
)
GO
CREATE TABLE TBLPROGRAMACION(
ID_PROGR INT IDENTITY(1111,1111)PRIMARY KEY NOT NULL,
NEDICION_PROGR VARCHAR(15) NOT NULL,
FECHA_PROGR VARCHAR(20) NOT NULL,
COD_EMPL_PROG VARCHAR(25) NOT NULL,
NRODOC_EMPL_PROG VARCHAR(20) ,
COD_CURSO_PROG INT  NOT NULL
)
GO
CREATE TABLE TBLFORMASDEPAGO(
CODIGO_PAGO VARCHAR(25) PRIMARY KEY NOT NULL,
NOMBRE_PAGO VARCHAR(20) NOT NULL,
COD_EMPL_PAGO VARCHAR(25) NOT NULL
)
--==========REFERENCIAR LAS FOREIGN KEY============ 
GO
ALTER TABLE TBLCLIENTE ADD FOREIGN KEY(COD_EMPL_CLI)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
ALTER TABLE TBLCARGO ADD FOREIGN KEY(COD_EMPL_CARGO)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
ALTER TABLE TBLPRERREQUISITO ADD FOREIGN KEY(COD_EMPL_PRE)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
ALTER TABLE TBLPRERREQUISITO ADD FOREIGN KEY(COD_CURSO_PRE)
REFERENCES TBLCURSOS(CODIGO_CURSO)
GO
ALTER TABLE TBLTEMAS ADD FOREIGN KEY(COD_CURSO_TEMAS)
REFERENCES TBLCURSOS(CODIGO_CURSO)
GO
ALTER TABLE TBLTEMAS ADD FOREIGN KEY(COD_EMPL_TEMAS)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
ALTER TABLE TBLMATRICULA ADD FOREIGN KEY(COD_EMPL_MATRI)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
ALTER TABLE TBLMATRICULA ADD FOREIGN KEY(CEDCLIENTE_MATRI)
REFERENCES TBLCLIENTE(CEDULA_CLI)
GO
ALTER TABLE TBLMATRICULA ADD FOREIGN KEY(COD_PAGO_MATRI)
REFERENCES TBLFORMASDEPAGO(CODIGO_PAGO)
GO
ALTER TABLE TBLDETALLEMATRICULA ADD FOREIGN KEY(COD_MATRI_DETA)
REFERENCES TBLMATRICULA(COD_MATRI)
GO
ALTER TABLE TBLDETALLEMATRICULA ADD FOREIGN KEY(ID_PROG_DETA)
REFERENCES TBLPROGRAMACION(ID_PROGR)
GO
ALTER TABLE TBLPROGRAMACION ADD FOREIGN KEY(COD_EMPL_PROG)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
ALTER TABLE TBLPROGRAMACION ADD FOREIGN KEY(COD_CURSO_PROG)
REFERENCES TBLCURSOS(CODIGO_CURSO)
GO
ALTER TABLE TBLFORMASDEPAGO ADD FOREIGN KEY(COD_EMPL_PAGO)
REFERENCES TBLEMPLEADO(CODEMPLEADO)
GO
--========INSERTAR INFORMACION EMPLEADO=======
INSERT INTO TBLEMPLEADO VALUES ('1010','1017231329','JUAN DIEGO ZAPATA DUQUE',
'2014/07/01','jdzapata','123juan')
INSERT INTO TBLEMPLEADO VALUES ('2020','71614817','CARLOS ALBERTO ZAPATA JIMENEZ',
'1980/03/21','cajimenez','123carlos')
INSERT INTO TBLEMPLEADO VALUES ('3030','12022485','ANDRES BENAVIDES','2007/10/06',
'abenavides','1233andres')
INSERT INTO TBLEMPLEADO VALUES ('4040','33445556','NATALIA VASQUEZ','2001/10/11',
'nvasquez','123nata')
GO
--======INSERTAR INFORMACION CURSOS======
INSERT INTO TBLCURSOS VALUES (1,'Programaci�n en Android',80)
INSERT INTO TBLCURSOS VALUES (2,'Programaci�n en Windows Phone',70)
INSERT INTO TBLCURSOS VALUES (3,'FRONTEND',50)
INSERT INTO TBLCURSOS VALUES (4,'BACKEND en Ruby On Rails',100)
INSERT INTO TBLCURSOS VALUES (5,'Programaci�n para la web con PHP',60)
INSERT INTO TBLCURSOS VALUES (6,'Desarrollo de software',120)
INSERT INTO TBLCURSOS VALUES (7,'Bases de Datos',90)
GO
--======INSERTAR INFORMACION CARGO======
INSERT INTO TBLCARGO (CODIGO_CARGO,DESCRIPCION_CARGO,COD_EMPL_CARGO)
VALUES('10','PROFESOR','1010')
GO
INSERT INTO TBLCARGO (CODIGO_CARGO,DESCRIPCION_CARGO,COD_EMPL_CARGO)
VALUES('20','SECRETARIA','4040')
GO
INSERT INTO TBLCARGO (CODIGO_CARGO,DESCRIPCION_CARGO,COD_EMPL_CARGO)
VALUES('30','DECANO','2020')
GO
--=========INSERTAR DATOS CLIENTES===========
INSERT INTO TBLCLIENTE(CEDULA_CLI,NOMBRE_CLI,EDAD_CLI,TELEFONO_CLI,CELULAR_CLI,
DIRECCION_CLIENTE,COD_EMPL_CLI)
VALUES('980722356','ANA MARIA ZAPATA',17,5878870,3113567815,'CALLE 45 AVENIDA LAS VEGAS',
'1010')
GO
INSERT INTO TBLCLIENTE(CEDULA_CLI,NOMBRE_CLI,EDAD_CLI,TELEFONO_CLI,
CELULAR_CLI,DIRECCION_CLIENTE,COD_EMPL_CLI)
VALUES('43540578','ESTELA DUQUE',30,8282158,3113887615,'CALLE 101 LOS PINOS',
'2020')
GO
INSERT INTO TBLCLIENTE(CEDULA_CLI,NOMBRE_CLI,EDAD_CLI,TELEFONO_CLI,CELULAR_CLI,
DIRECCION_CLIENTE,COD_EMPL_CLI)
VALUES('25431258','ALEJANDRA VASQUEZ',19,8280422,3001456879,'CALLE 23 AVENIDA LAURELES',
'4040')
GO
--=======INSERTAR DATOS PRERREQUISITO=======
INSERT INTO TBLPRERREQUISITO
VALUES('FRONTEND',1,'1010')
GO
INSERT INTO TBLPRERREQUISITO
VALUES('Desarrollo de software',5,'1010')
GO
INSERT INTO TBLPRERREQUISITO
VALUES('BASES DE DATOS',6,'2020')
GO

--=========INSERTAR DATOSTEMAS===========
INSERT INTO TBLTEMAS
VALUES('POO,BD Y MVC PHP',5,'1010')
GO
INSERT INTO TBLTEMAS
VALUES('POO, BASES DE DATOS EN SQL LITE, WREB SERVICES, NOTIFICACIONES PUSH Y
USO DEL HARDWARE(CAMARA,GPS)',1,'3030')
GO
INSERT INTO TBLTEMAS
VALUES('MVC AVANZADO EN RUBY,BASES DE DATOS EN MYSQL,PUBLICACI�N DE LA
 P�GINA EN INTERNET',4,'1010')
GO
INSERT INTO TBLTEMAS
VALUES('POO NETO, USO DE LIBRERIAS DLL,REGLAS DE NEGOCIO,HERENCIA 
Y POLIMORFISMO, BD EN SQL SERVER',6,'1010')
GO
--========INSERTAR DATOS FORMAS DE PAGO==========
INSERT INTO TBLFORMASDEPAGO(CODIGO_PAGO,NOMBRE_PAGO,COD_EMPL_PAGO)
VALUES('1000','EFECTIVO','1010')
GO
INSERT INTO TBLFORMASDEPAGO(CODIGO_PAGO,NOMBRE_PAGO,COD_EMPL_PAGO)
VALUES('2000','TCREDITO','4040')
GO
INSERT INTO TBLFORMASDEPAGO(CODIGO_PAGO,NOMBRE_PAGO,COD_EMPL_PAGO)
VALUES('3000','TDEBITO','3030')
GO
INSERT INTO TBLFORMASDEPAGO(CODIGO_PAGO,NOMBRE_PAGO,COD_EMPL_PAGO)
VALUES('4000','CHEQUE','4040')
GO
--========INSERTAR DATOS MATRICULA==========
INSERT INTO TBLMATRICULA(COD_MATRI,CEDCLIENTE_MATRI,COD_EMPL_MATRI,COD_PAGO_MATRI)
VALUES('1001','980722356','1010','1000')
GO
INSERT INTO TBLMATRICULA(COD_MATRI,CEDCLIENTE_MATRI,COD_EMPL_MATRI,COD_PAGO_MATRI)
VALUES('1002','43540578','2020','3000')
GO
INSERT INTO TBLMATRICULA(COD_MATRI,CEDCLIENTE_MATRI,COD_EMPL_MATRI,COD_PAGO_MATRI)
VALUES('1003','25431258','4040','4000')
GO
--========INSERTAR DATOS PROGRAMACI�N==========
INSERT INTO TBLPROGRAMACION
VALUES('2015-2','2015/07/08','1010','1017231329',1)
GO
INSERT INTO TBLPROGRAMACION
VALUES('2013-2','2013/09/20','2020','71614817',4)
GO
INSERT INTO TBLPROGRAMACION
VALUES('2017-1','2017/02/05','4040','33445556',7)
GO
INSERT INTO TBLPROGRAMACION
VALUES('2014-2','2014/07/15','1010','12022485',3)
GO
--========INSERTAR DATOS DETALLE MATRICULA==========
INSERT INTO TBLDETALLEMATRICULA(COD_MATRI_DETA,DESCRIPCION_DETMATRI,
VALOR_MATRI_DETA,ID_PROG_DETA)
VALUES('1002','CURSO DE PROGRAMACION EN ANDROID',190500,1111)
GO
INSERT INTO TBLDETALLEMATRICULA(COD_MATRI_DETA,DESCRIPCION_DETMATRI,
VALOR_MATRI_DETA,ID_PROG_DETA)
VALUES('1003','BACKEND EN RUBY ON RAILS',3000000,2222)
GO
INSERT INTO TBLDETALLEMATRICULA(COD_MATRI_DETA,DESCRIPCION_DETMATRI,
VALOR_MATRI_DETA,ID_PROG_DETA)
VALUES('1001','FRONTEND',260000,4444)
GO
--select NOMBRE_EMPL from TBLEMPLEADO 
--inner join TBLCARGO
--on COD_EMPL_CARGO=CODEMPLEADO
--=====================LOGIN==========
-----=========================
CREATE PROC loginCC @user VARCHAR(25),
@password VARCHAR(25)
AS
BEGIN
SELECT USUARIO_PROF  AS Usuario
FROM TBLEMPLEADO
Where USUARIO_PROF=@user and
CLAVE_PROFESOR=@password
SELECT @user AS Rpta
Return
END
GO
--===========LLENAR COMBO CURSOS=============
CREATE PROC LlenarComboCursos
AS
BEGIN
SELECT CODIGO_CURSO as Clave,
TITULO_CURSO As Dato
FROM TBLCURSOS
ORDER BY TITULO_CURSO
--EXEC USP_Asoc_LlenarCombo
END
GO
--===========LLENAR RADIO Cargo=============
CREATE PROC LlenarRadioEmpleados
AS
BEGIN
SELECT CODEMPLEADO as Clave,
DESCRIPCION_CARGO As Dato
FROM TBLCARGO INNER JOIN TBLEMPLEADO
ON CODEMPLEADO=COD_EMPL_CARGO
ORDER BY DESCRIPCION_CARGO
--EXEC USP_Asoc_LlenarCombo
END
GO
--===========LLENAR RADIO Formas de pago=============
CREATE PROC LlenarRadioFormasdePago
AS
BEGIN
SELECT CODIGO_PAGO as Clave,
NOMBRE_PAGO As Dato
FROM TBLFORMASDEPAGO
ORDER BY NOMBRE_PAGO
--EXEC USP_Asoc_LlenarCombo
END
GO
--===========LLENAR ChecBox prerrequisitos=============
CREATE PROC LlenarCBPrerrequisitos
AS
BEGIN
SELECT COD_PRE as Clave, DESCRIPCION_PRE as Dato  FROM TBLPRERREQUISITO
INNER JOIN TBLCURSOS ON TITULO_CURSO=DESCRIPCION_PRE
ORDER BY DESCRIPCION_PRE
--EXEC LlenarCBPrerrequisitos
END
GO
--=======llenarGrid Cursos=========
CREATE PROC llenarGridCursos
AS
BEGIN
SELECT CODIGO_CURSO as C�digo,
TITULO_CURSO as Nombre
FROM TBLCURSOS
ORDER BY TITULO_CURSO
--exec USP_TipoDoc_BuscarGeneral
END 
GO
--=========BUSCAR CURSO POR CODIGO============
CREATE PROC BuscarCursoXCodigo @intCodCurso int
AS
BEGIN
SELECT CODIGO_CURSO AS C�digo,
TITULO_CURSO as Nombre
FROM TBLCURSOS
Where CODIGO_CURSO=@intCodCurso
END
GO
--=========NUMERO DE CURSOS==========
create  proc  nroCursos
as
begin
select COUNT(*) from TBLCURSOS
return
end
GO
--=========GrabarCurso===========
CREATE PROC CrearNuevoCurso
@strTituloCurso VARCHAR(40),
@intHoras int,
@strnEdicion VARCHAR(25),
@dblValor REAL,
@strTemas varchar(4000),
@strPrerre varchar(25),
@dtmFechainicio VARCHAR(25),
@strCodEmple varchar(25),
@strNroDocEmpl varchar(25),
@intCodcurso int
AS
BEGIN 
IF EXISTS(
SELECT *FROM  TBLCURSOS 
WHERE CODIGO_CURSO=@intCodcurso OR
TITULO_CURSO=@strTituloCurso)
BEGIN 
SELECT -1 AS Rpta
Return
END
ELSE
BEGIN
BEGIN TRANSACTION tx
INSERT INTO TBLCURSOS
VALUES(@intCodcurso, @strTituloCurso,@intHoras);
--
INSERT INTO TBLPROGRAMACION
VALUES(@strnEdicion,@dtmFechainicio,@strCodEmple,
@strNroDocEmpl,@intCodcurso);
----
--INSERT INTO TBLDETALLEMATRICULA
--VALUES(@,@strTituloCurso,@dblValor,@@IDENTITY);
--
INSERT INTO TBLPRERREQUISITO
VALUES(@strPrerre,@intCodcurso,@strCodEmple);
----
INSERT INTO TBLTEMAS
VALUES(@strTemas,@intCodcurso,@strCodEmple);
--
IF(@@ERROR>0)
BEGIN
ROLLBACK TRANSACTION tx
SELECT 0 AS Rpta
Return
END
COMMIT TRANSACTION tx
SELECT @strTituloCurso AS Rpta
Return
END
END
go
---===============MODIFICAR CREAR CURSO===============
CREATE PROC ModificarCursoCreado
@intCodigocurso int,
@strtituloCurso VARCHAR(25),
@intNhoras int,
@strTemas varchar(25)
AS
BEGIN
IF EXISTS(
SELECT * FROM TBLCURSOS
WHERE CODIGO_CURSO<>@intCodigocurso AND
TITULO_CURSO=@strtituloCurso)
BEGIN
SELECT -1 AS Rpta
Return
END
ELSE
BEGIN
BEGIN TRANSACTION tx
UPDATE TBLCURSOS
SET TITULO_CURSO=@strtituloCurso,
NHORAS_CURSO=@intNhoras
WHERE CODIGO_CURSO =@intCodigocurso
--
UPDATE TBLTEMAS
SET DESCRIPCION_TEMAS=@strTemas
WHERE COD_CURSO_TEMAS =@intCodigocurso
IF(@@ERROR>0)
BEGIN
ROLLBACK TRANSACTION tx
SELECT 0 AS Rpta
Return
END
COMMIT TRANSACTION tx
SELECT @strtituloCurso AS Rpta
Return
END
END
GO
--==========================================
--==========PARA IMPRESION=================
--Tipo de documento
--14
CREATE  PROC CrearCursoImpresion
@intCod int
AS
BEGIN
SELECT CODIGO_CURSO As C�digo,
TITULO_CURSO  as Descripci�n
FROM TBLCURSOS
WHERE CODIGO_CURSO=@intCod
ORDER BY C�digo
--EXEC usp_sTipoDoc_Impresion 'CC'
END
GO
CREATE PROCEDURE BuscarEstuXCodigo
@strCed VARCHAR(25)
AS
	BEGIN
	SELECT CEDULA_CLI AS Clave,
		   NOMBRE_CLI AS Nombre,
		   EDAD_CLI AS Edad,
		   TELEFONO_CLI AS Tel�fono,
		   CELULAR_CLI AS Celular,
		   DIRECCION_CLIENTE AS Direcci�n
	FROM TBLCLIENTE
	WHERE CEDULA_CLI = @strCed
	END
GO 
--==========GRABAR ESTUDIANTE===============
CREATE PROC GrabarEstudiante
@strCedCli VARCHAR(25),
@strNombreCli VARCHAR(40),
@IntEdad REAL,
@bigTelefonoCli REAL,
@BigCelularCli REAL,
@strDirCli varchar(50),
@strCodEmple varchar(25),
@strCodPago varchar(25),
@intCodCurso int,
@strTituloCurso varchar(25),
@strCodMatri varchar(25)
AS
BEGIN 
IF EXISTS(
SELECT *FROM  TBLEMPLEADO 
WHERE NRODOC_EMPL=@strCedCli OR
NOMBRE_EMPL=@strNombreCli)
OR  EXISTS(
SELECT *FROM  TBLMATRICULA 
WHERE COD_MATRI=@strCodMatri)
BEGIN 
SELECT -1 AS Rpta
Return
END
ELSE
BEGIN
BEGIN TRANSACTION tx
INSERT INTO TBLCLIENTE
VALUES(@strCedCli,@strNombreCli,@IntEdad,@bigTelefonoCli,
@BigCelularCli,@strDirCli,@strCodEmple);
--Insertar datos del cliente
INSERT INTO TBLMATRICULA(COD_MATRI,CEDCLIENTE_MATRI,COD_EMPL_MATRI,
COD_PAGO_MATRI)
VALUES(@strCodMatri,@strCedCli,@strCodEmple,@strCodPago);
----INSERTAR DATOS DE LA MATRICULA
INSERT INTO TBLDETALLEMATRICULA
VALUES(@strCodMatri,@strTituloCurso,170000,1111);
----INSERTAR DATOS DE LA MATRICULA
IF(@@ERROR>0)
BEGIN
ROLLBACK TRANSACTION tx
SELECT 0 AS Rpta
Return
END
COMMIT TRANSACTION tx
SELECT @strCedCli AS Rpta
Return
END
END
go
---========================================
CREATE PROC llenarGridEstudiantes
AS
BEGIN
SELECT CEDULA_CLI as C�dula,
NOMBRE_CLI as Nombre,
DESCRIPCION_DETMATRI as Curso,
VALOR_MATRI_DETA as Costo
FROM TBLCLIENTE INNER JOIN
TBLMATRICULA ON CEDCLIENTE_MATRI=CEDULA_CLI
INNER JOIN TBLDETALLEMATRICULA ON
COD_MATRI=COD_MATRI_DETA
ORDER BY NOMBRE_CLI
--exec USP_TipoDoc_BuscarGeneral
END 
GO
--select NOMBRE_EMPL from TBLEMPLEADO 
--inner join TBLCARGO
--on COD_EMPL_CARGO=CODEMPLEADO
---===============MODIFICAR CREAR CURSO===============
CREATE PROC ModificarEstudiante
@strCedCliente varchar(25),
@strNombreCompleto VARCHAR(40),
@dblEdad REAL,
@dblTelefono REAL,
@dblCelular REAL,
@strDir varchar(50)
AS
BEGIN
IF EXISTS(
SELECT * FROM TBLCLIENTE
WHERE CEDULA_CLI<>@strCedCliente AND
NOMBRE_CLI=@strNombreCompleto)
BEGIN
SELECT -1 AS Rpta
Return
END
ELSE
BEGIN
BEGIN TRANSACTION tx
UPDATE TBLCLIENTE
SET NOMBRE_CLI=@strNombreCompleto,
EDAD_CLI=@dblEdad,TELEFONO_CLI=@dblTelefono,
CELULAR_CLI=@dblCelular,DIRECCION_CLIENTE=@strDir
WHERE CEDULA_CLI =@strCedCliente
IF(@@ERROR>0)
BEGIN
ROLLBACK TRANSACTION tx
SELECT 0 AS Rpta
Return
END
COMMIT TRANSACTION tx
SELECT @strCedCliente AS Rpta
Return
END
END
GO
--==========================================
CREATE  PROC EstudianteImpresion
@strCed varchar(25)
AS
BEGIN
SELECT CEDULA_CLI as C�dula,
NOMBRE_CLI as Nombre,
DESCRIPCION_DETMATRI as Curso,
VALOR_MATRI_DETA as Costo
FROM TBLCLIENTE INNER JOIN
TBLMATRICULA ON CEDCLIENTE_MATRI=CEDULA_CLI
INNER JOIN TBLDETALLEMATRICULA ON
COD_MATRI=COD_MATRI_DETA
WHERE CEDULA_CLI=@strCed
--EXEC usp_sTipoDoc_Impresion 'CC'
END
GO
--================BuscarMatriculaporCedula====================
CREATE PROC BuscarMatriculaporCedula
@strCed varchar(25)
AS
BEGIN
SELECT CEDULA_CLI as C�dula,
NOMBRE_CLI as Nombre,
DESCRIPCION_DETMATRI as Curso,
VALOR_MATRI_DETA as Costo
FROM TBLCLIENTE INNER JOIN
TBLMATRICULA ON CEDCLIENTE_MATRI=CEDULA_CLI
INNER JOIN TBLDETALLEMATRICULA ON
COD_MATRI=COD_MATRI_DETA
WHERE CEDULA_CLI=@strCed
END 
GO
---=========buscar valor matricula==============
CREATE PROC BuscarValor @strCod varchar(25)
AS
BEGIN
SELECT VALOR_MATRI_DETA AS Clave
FROM TBLDETALLEMATRICULA
Where COD_MATRI_DETA=@strCod
END
GO
--==============llenarGridTemas===================
CREATE PROC llenarGridTemas
AS
BEGIN
SELECT COD_TEMAS as C�digo,
DESCRIPCION_TEMAS as Temas,
TITULO_CURSO as Curso
FROM TBLTEMAS INNER JOIN
TBLCURSOS ON CODIGO_CURSO=COD_CURSO_TEMAS
ORDER BY TITULO_CURSO
--exec USP_TipoDoc_BuscarGeneral
END 
GO
--==============temasxCod
CREATE PROC llenarGridTemasxCod
@intCod int
AS
BEGIN
SELECT COD_TEMAS as C�digo,
DESCRIPCION_TEMAS as Temas,
TITULO_CURSO as Curso
FROM TBLTEMAS INNER JOIN
TBLCURSOS ON CODIGO_CURSO=COD_CURSO_TEMAS
WHERE COD_TEMAS=@intCod
END 
GO

--select DESCRIPCION_PRE as prerrequisito,TITULO_CURSO as Curso
 --from TBLPRERREQUISITO inner join
--TBLCURSOS on CODIGO_CURSO=COD_CURSO_PRE
--==============llenar empleadosGrid==============
CREATE PROC llenarGridEmpleados
AS
BEGIN
SELECT DESCRIPCION_CARGO AS Cargo,NOMBRE_EMPL as Empleado
 FROM TBLEMPLEADO INNER JOIN
TBLCARGO ON CODEMPLEADO=COD_EMPL_CARGO
END 
GO
--==========buscarporCodiEmpleado================
CREATE PROC llenarGridEmpleadosxCod
@strCod varchar(25)
AS
BEGIN
SELECT DESCRIPCION_CARGO AS Cargo,NOMBRE_EMPL as Empleado
 FROM TBLEMPLEADO INNER JOIN
TBLCARGO ON CODEMPLEADO=COD_EMPL_CARGO
where CODEMPLEADO=@strCod
END 
GO
--=================================
