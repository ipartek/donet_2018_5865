USE [master]
GO
/****** Object:  Database [ipartek]    Script Date: 26/02/2019 11:04:42 ******/
CREATE DATABASE [ipartek]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ipartek', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ipartek.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ipartek_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ipartek_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ipartek] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ipartek].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ipartek] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ipartek] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ipartek] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ipartek] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ipartek] SET ARITHABORT OFF 
GO
ALTER DATABASE [ipartek] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ipartek] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ipartek] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ipartek] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ipartek] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ipartek] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ipartek] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ipartek] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ipartek] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ipartek] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ipartek] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ipartek] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ipartek] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ipartek] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ipartek] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ipartek] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ipartek] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ipartek] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ipartek] SET  MULTI_USER 
GO
ALTER DATABASE [ipartek] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ipartek] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ipartek] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ipartek] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ipartek] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ipartek] SET QUERY_STORE = OFF
GO
USE [ipartek]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 26/02/2019 11:04:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 
GO
INSERT [dbo].[usuarios] ([Id], [Email], [Password]) VALUES (1, N'javierlete@email.net', N'contra')
GO
INSERT [dbo].[usuarios] ([Id], [Email], [Password]) VALUES (2, N'pepe@email.net', N'yepa')
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
USE [master]
GO
ALTER DATABASE [ipartek] SET  READ_WRITE 
GO
