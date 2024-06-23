USE [master]
GO
/****** Object:  Database [Empleados]    Script Date: 22/06/2024 23:59:02 ******/
CREATE DATABASE [Empleados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Empleados', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Empleados.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Empleados_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Empleados_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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

INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento]) VALUES (5, N'John', N'Doe', CAST(N'1990-06-12' AS Date), CAST(N'2020-02-14' AS Date), 1, 1, 3)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento]) VALUES (6, N'Jane', N'Doe', CAST(N'1988-10-06' AS Date), CAST(N'2023-12-03' AS Date), 1, 3, 4)
INSERT [dbo].[Empleado] ([idEmpleado], [nombre], [apellido], [fechaNac], [fechaIngreso], [idGenero], [idPais], [idDepartamento]) VALUES (7, N'Bruce', N'Willis', CAST(N'1955-03-19' AS Date), CAST(N'2006-04-12' AS Date), 2, 5, 1)
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
