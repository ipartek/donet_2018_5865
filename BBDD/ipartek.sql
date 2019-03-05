USE [master]
GO
/****** Object:  Database [ipartek]    Script Date: 05/03/2019 14:12:34 ******/
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
/****** Object:  Table [dbo].[EntradasBlog]    Script Date: 05/03/2019 14:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntradasBlog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Texto] [text] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EntradaBlog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 05/03/2019 14:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](10) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/03/2019 14:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NULL,
	[IdTutor] [int] NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosEntradasBlog]    Script Date: 05/03/2019 14:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosEntradasBlog](
	[IdEntradaBlog] [int] NOT NULL,
	[IdUsuarios] [int] NOT NULL,
 CONSTRAINT [PK_UsuariosEntradaBlog] PRIMARY KEY CLUSTERED 
(
	[IdEntradaBlog] ASC,
	[IdUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EntradasBlog] ON 

INSERT [dbo].[EntradasBlog] ([Id], [Titulo], [Texto], [Fecha]) VALUES (1, N'Mi primera entrada', N'Las entradas están en el pelo.', CAST(N'2019-03-05T13:24:20.9333333' AS DateTime2))
INSERT [dbo].[EntradasBlog] ([Id], [Titulo], [Texto], [Fecha]) VALUES (2, N'Mi segunda entrada', N'Están sobrevaloradas', CAST(N'2019-03-05T13:25:19.1866667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EntradasBlog] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion]) VALUES (1, N'ADMIN', N'Administradores')
INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion]) VALUES (2, N'USER', N'Usuarios')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (1, 1, NULL, N'javierlete@email.net', N'contra')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (2, 2, 1, N'pepe@email.net', N'yepa')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (3, 2, 2, N'juan@email.net', N'guau')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (1, 1)
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (2, 1)
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (2, 2)
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (2, 3)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_Email]    Script Date: 05/03/2019 14:12:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios_Email] ON [dbo].[Usuarios]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EntradasBlog] ADD  CONSTRAINT [DF_EntradaBlog_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios] FOREIGN KEY([IdTutor])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios]
GO
ALTER TABLE [dbo].[UsuariosEntradasBlog]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosEntradaBlog_EntradaBlog] FOREIGN KEY([IdEntradaBlog])
REFERENCES [dbo].[EntradasBlog] ([Id])
GO
ALTER TABLE [dbo].[UsuariosEntradasBlog] CHECK CONSTRAINT [FK_UsuariosEntradaBlog_EntradaBlog]
GO
ALTER TABLE [dbo].[UsuariosEntradasBlog]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosEntradaBlog_Usuarios] FOREIGN KEY([IdUsuarios])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[UsuariosEntradasBlog] CHECK CONSTRAINT [FK_UsuariosEntradaBlog_Usuarios]
GO
USE [master]
GO
ALTER DATABASE [ipartek] SET  READ_WRITE 
GO
