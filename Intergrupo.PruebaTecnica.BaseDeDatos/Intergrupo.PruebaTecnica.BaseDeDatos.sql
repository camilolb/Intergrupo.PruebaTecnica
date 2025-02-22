USE [master]
GO
/****** Object:  Database [Intergrupo.PruebaTecnica]    Script Date: 12/24/2018 11:38:23 ******/
CREATE DATABASE [Intergrupo.PruebaTecnica] ON  PRIMARY 
( NAME = N'Intergrupo.PruebaTecnica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Intergrupo.PruebaTecnica.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Intergrupo.PruebaTecnica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Intergrupo.PruebaTecnica_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Intergrupo.PruebaTecnica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET ARITHABORT OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET  DISABLE_BROKER
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET  READ_WRITE
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET RECOVERY FULL
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET  MULTI_USER
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Intergrupo.PruebaTecnica] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Intergrupo.PruebaTecnica', N'ON'
GO
USE [Intergrupo.PruebaTecnica]
GO
/****** Object:  User [usrPruebaTecnica]    Script Date: 12/24/2018 11:38:23 ******/
CREATE USER [usrPruebaTecnica] FOR LOGIN [usrPruebaTecnica] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[pedido]    Script Date: 12/24/2018 11:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[ValorPedido] [int] NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 12/24/2018 11:38:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](150) NULL,
	[Apellidos] [nvarchar](150) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Telefono], [Celular]) VALUES (1, N'dsfdsf', N'dsfdsf', N'45435', N'43534')
SET IDENTITY_INSERT [dbo].[cliente] OFF
