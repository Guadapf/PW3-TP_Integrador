USE [master]
GO
/****** Object:  Database [Nomina]    Script Date: 22/06/2024 23:59:43 ******/
CREATE DATABASE [Nomina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nomina', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Nomina.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nomina_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Nomina_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Nomina] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nomina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nomina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nomina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nomina] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Nomina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nomina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nomina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nomina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nomina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nomina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nomina] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Nomina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nomina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nomina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nomina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nomina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nomina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nomina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nomina] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nomina] SET  MULTI_USER 
GO
ALTER DATABASE [Nomina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nomina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nomina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nomina] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nomina] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Nomina] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Nomina] SET QUERY_STORE = OFF
GO
USE [Nomina]
GO

/****** Object:  Table [dbo].[Antiguedad]    Script Date: 22/06/2024 23:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antiguedad](
	[idAntiguedad] [int] IDENTITY(1,1) NOT NULL,
	[anios] [int] NULL,
	[bono] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compensacion]    Script Date: 22/06/2024 23:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compensacion](
	[idCompensacion] [int] IDENTITY(1,1) NOT NULL,
	[idDepartamento] [int] NULL,
	[multiplicador] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalarioBase]    Script Date: 22/06/2024 23:59:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalarioBase](
	[idSalarioBase] [int] IDENTITY(1,1) NOT NULL,
	[idPais] [int] NULL,
	[salario] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Antiguedad] ON 

INSERT [dbo].[Antiguedad] ([idAntiguedad], [anios], [bono]) VALUES (1, 1, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Antiguedad] ([idAntiguedad], [anios], [bono]) VALUES (2, 5, CAST(150.00 AS Decimal(10, 2)))
INSERT [dbo].[Antiguedad] ([idAntiguedad], [anios], [bono]) VALUES (3, 8, CAST(200.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Antiguedad] OFF
GO
SET IDENTITY_INSERT [dbo].[Compensacion] ON 

INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (1, 1, CAST(1.20 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (2, 2, CAST(0.80 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (3, 3, CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (4, 4, CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (5, 5, CAST(0.60 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (6, 6, CAST(1.15 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (7, 7, CAST(1.30 AS Decimal(10, 2)))
INSERT [dbo].[Compensacion] ([idCompensacion], [idDepartamento], [multiplicador]) VALUES (8, 8, CAST(1.05 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Compensacion] OFF
GO
SET IDENTITY_INSERT [dbo].[SalarioBase] ON 

INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (1, 1, CAST(152.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (2, 2, CAST(570.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (3, 3, CAST(367.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (4, 4, CAST(521.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (5, 5, CAST(342.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (6, 6, CAST(291.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (7, 7, CAST(277.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (8, 8, CAST(335.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (9, 9, CAST(3.61 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (10, 10, CAST(440.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (11, 11, CAST(460.00 AS Decimal(10, 2)))
INSERT [dbo].[SalarioBase] ([idSalarioBase], [idPais], [salario]) VALUES (12, 12, CAST(680.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[SalarioBase] OFF
GO
USE [master]
GO
ALTER DATABASE [Nomina] SET  READ_WRITE 
GO
