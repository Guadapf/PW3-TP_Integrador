USE [master]
GO
/****** Object:  Database [Empleados]    Script Date: 22/06/2024 23:59:02 ******/
CREATE DATABASE [Empleados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empleados', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Empleados.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Empleados_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Empleados_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Empleados] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Empleados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Empleados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Empleados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Empleados] SET ARITHABORT OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Empleados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Empleados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Empleados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Empleados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Empleados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Empleados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Empleados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Empleados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Empleados] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Empleados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Empleados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Empleados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Empleados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Empleados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Empleados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Empleados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Empleados] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Empleados] SET  MULTI_USER 
GO
ALTER DATABASE [Empleados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Empleados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Empleados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Empleados] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Empleados] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Empleados] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Empleados] SET QUERY_STORE = OFF
GO
USE [Empleados]
GO

/****** Object:  Table [dbo].[Departamento]    Script Date: 22/06/2024 23:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[idDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 22/06/2024 23:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fechaNac] [date] NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[idGenero] [int] NOT NULL,
	[idPais] [int] NOT NULL,
	[idDepartamento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 22/06/2024 23:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[idGenero] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[idGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 22/06/2024 23:59:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (1, N'Finanzas')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (2, N'Ventas')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (3, N'Marketing')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (4, N'Legal')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (5, N'Operaciones')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (6, N'Servicio al Cliente')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (7, N'Comunicación Corporativa')
INSERT [dbo].[Departamento] ([idDepartamento], [descripcion]) VALUES (8, N'Tecnología de la Información')
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (1, N'Mariano', N'Borrego', CAST('1987-01-27' AS Date), CAST('2020-01-31' AS Date), 3, 1, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (2, N'Luis Javier', N'Lucena', CAST('1998-11-22' AS Date), CAST('2020-11-11' AS Date), 3, 2, 2)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (3, N'Federico', N'Quiles', CAST('1996-04-14' AS Date), CAST('2018-03-15' AS Date), 2, 3, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (4, N'Israel', N'Heredia', CAST('1990-02-23' AS Date), CAST('2018-04-15' AS Date), 2, 4, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (5, N'Arturo', N'de La Torre', CAST('1985-09-23' AS Date), CAST('2021-07-17' AS Date), 2, 5, 5)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (6, N'Arturo', N'Solana', CAST('1998-07-08' AS Date), CAST('2021-12-23' AS Date), 2, 7, 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (7, N'Jose Domingo', N'Encinas', CAST('1997-10-05' AS Date), CAST('2021-08-20' AS Date), 2, 8, 7)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (8, N'Omar', N'Esteve', CAST('1992-05-04' AS Date), CAST('2023-05-06' AS Date), 2, 9, 8)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (9, N'Juan', N'Amat', CAST('1990-06-05' AS Date), CAST('2021-01-14' AS Date), 2, 10, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (10, N'Luis Carlos', N'Rosado', CAST('1981-01-15' AS Date), CAST('2021-03-25' AS Date), 2, 11, 2)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (11, N'Muhammad', N'Jérez', CAST('1986-12-16' AS Date), CAST('2021-05-11' AS Date), 2, 1, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (12, N'Josep', N'De-Diego', CAST('1988-08-05' AS Date), CAST('2023-03-19' AS Date), 2, 2, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (13, N'David', N'Ramiro', CAST('1994-01-02' AS Date), CAST('2022-05-12' AS Date), 2, 3, 5)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (14, N'Gaspar', N'Izquierdo', CAST('1986-07-13' AS Date), CAST('2022-11-16' AS Date), 2, 4, 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (15, N'Ahmed', N'Heredia', CAST('1999-06-27' AS Date), CAST('2022-10-18' AS Date), 2, 5, 7)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (16, N'Fermín', N'Borrego', CAST('1998-12-14' AS Date), CAST('2018-12-31' AS Date), 2, 7, 8)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (17, N'Tomás', N'Enríquez', CAST('1980-10-23' AS Date), CAST('2022-02-17' AS Date), 2, 8, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (18, N'José Andrés', N'Pallares', CAST('1996-06-14' AS Date), CAST('2022-10-11' AS Date), 2, 9, 2)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (19, N'Iñaki', N'Enríquez', CAST('1989-03-24' AS Date), CAST('2021-12-13' AS Date), 2, 10, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (20, N'Luis Alfonso', N'Barrera', CAST('1989-09-29' AS Date), CAST('2020-10-23' AS Date), 2, 11, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (21, N'Avelina', N'Mayoral', CAST('1995-08-11' AS Date), CAST('2018-01-06' AS Date), 1, 1, 5)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (22, N'Lara', N'Monge', CAST('1983-02-02' AS Date), CAST('2019-05-05' AS Date), 1, 2, 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (23, N'Virginia', N'Ponce', CAST('1987-07-21' AS Date), CAST('2021-08-06' AS Date), 1, 3, 7)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (24, N'María Purificación', N'Rosa', CAST('1991-09-20' AS Date), CAST('2023-02-22' AS Date), 1, 4, 8)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (25, N'Josefa María', N'Enríquez', CAST('1990-10-22' AS Date), CAST('2024-02-19' AS Date), 1, 5, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (26, N'Aurea', N'Muñoz', CAST('1997-02-15' AS Date), CAST('2021-11-11' AS Date), 1, 7, 2)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (27, N'Adelaida', N'Guijarro', CAST('1982-05-19' AS Date), CAST('2019-10-31' AS Date), 1, 8, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (28, N'Flora', N'Cordero', CAST('1991-07-06' AS Date), CAST('2020-12-05' AS Date), 1, 9, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (29, N'Modesta', N'Delgado', CAST('1988-06-27' AS Date), CAST('2018-12-22' AS Date), 3, 10, 5)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (30, N'Rosario', N'Samper', CAST('1992-12-23' AS Date), CAST('2023-10-24' AS Date), 3, 11, 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (31, N'Carmen Rosa', N'Ventura', CAST('1990-10-26' AS Date), CAST('2022-10-05' AS Date), 1, 1, 7)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (32, N'María Dolores', N'Pons', CAST('1983-06-18' AS Date), CAST('2020-01-25' AS Date), 1, 2, 8)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (33, N'Débora', N'Mayoral', CAST('1984-12-17' AS Date), CAST('2018-01-15' AS Date), 1, 3, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (34, N'Nieves', N'Rio', CAST('1992-09-11' AS Date), CAST('2022-06-18' AS Date), 1, 4, 2)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (35, N'Luz María', N'Mayo', CAST('1998-02-25' AS Date), CAST('2023-12-10' AS Date), 1, 5, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (36, N'María Amparo', N'Gascon', CAST('1991-05-08' AS Date), CAST('2021-02-12' AS Date), 1, 7, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (37, N'Otilia', N'Llanos', CAST('1998-12-09' AS Date), CAST('2023-03-24' AS Date), 1, 8, 5)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (38, N'María', N'Montserrat Ribera', CAST('1995-04-08' AS Date), CAST('2022-07-31' AS Date), 1, 9, 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (39, N'Estefanía', N'Palma', CAST('1989-09-17' AS Date), CAST('2024-05-05' AS Date), 1, 10, 7)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (40, N'Nazaret', N'Nadal', CAST('1991-11-03' AS Date), CAST('2018-08-06' AS Date), 1, 11, 8)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (41, N'Ricardo', N'Baptista', CAST('1999-03-16' AS Date), CAST('2021-02-23' AS Date), 2, 6, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (42, N'Roldão', N'Montenegro', CAST('1997-07-01' AS Date), CAST('2018-09-15' AS Date), 2, 6, 2)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (43, N'Cátia', N'Saraiva', CAST('1991-04-27' AS Date), CAST('2019-08-21' AS Date), 1, 6, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (44, N'Márcia', N'Neves', CAST('1985-02-15' AS Date), CAST('2018-06-10' AS Date), 1, 6, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (45, N'Manuela', N'Carriço', CAST('1985-01-07' AS Date), CAST('2019-05-16' AS Date), 1, 6, 5)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (46, N'Jeremy', N'Pérez Moret', CAST('1993-06-30' AS Date), CAST('2019-02-19' AS Date), 2, 12, 6)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (47, N'Jonathan', N'Caballero Galarza', CAST('1981-09-30' AS Date), CAST('2021-05-20' AS Date), 2, 12, 7)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (48, N'Krystal', N'Acosta del Valle', CAST('1994-07-11' AS Date), CAST('2020-06-21' AS Date), 1, 12, 8)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (49, N'Khloe', N'Narvaez Vargas', CAST('1984-03-22' AS Date), CAST('2022-07-05' AS Date), 3, 12, 1)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento])
VALUES (50, N'Stella', N'Segarra Quintana', CAST('1987-07-15' AS Date), CAST('2019-01-23' AS Date), 1, 12, 2)

SET IDENTITY_INSERT [dbo].[Empleado] OFF
GO

SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([idGenero], [descripcion]) VALUES (1, N'F')
INSERT [dbo].[Genero] ([idGenero], [descripcion]) VALUES (2, N'M')
INSERT [dbo].[Genero] ([idGenero], [descripcion]) VALUES (3, N'O')
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 

INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (1, N'Argentina')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (2, N'Uruguay')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (3, N'Paraguay')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (4, N'Chile')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (5, N'Bolivia')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (6, N'Brasil')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (7, N'Peru')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (8, N'Colombia')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (9, N'Venezuela')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (10, N'Mexico')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (11, N'Ecuador')
INSERT [dbo].[Pais] ([idPais], [descripcion]) VALUES (12, N'Puerto Rico')
SET IDENTITY_INSERT [dbo].[Pais] OFF
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([idDepartamento])
REFERENCES [dbo].[Departamento] ([idDepartamento])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([idGenero])
REFERENCES [dbo].[Genero] ([idGenero])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([idPais])
REFERENCES [dbo].[Pais] ([idPais])
GO
USE [master]
GO
ALTER DATABASE [Empleados] SET  READ_WRITE 
GO
