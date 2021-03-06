USE [master]
GO
/****** Object:  Database [ipartek]    Script Date: 20/03/2019 9:31:40 ******/
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
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF;
GO
USE [ipartek]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 20/03/2019 9:31:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](10) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 20/03/2019 9:31:41 ******/
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
/****** Object:  View [dbo].[UsuariosDeRolUser]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UsuariosDeRolUser]
AS
SELECT        dbo.Usuarios.Id, dbo.Usuarios.Email, dbo.Usuarios.Password
FROM            dbo.Usuarios INNER JOIN
                         dbo.Roles ON dbo.Usuarios.IdRol = dbo.Roles.Id
WHERE        (dbo.Roles.Rol = 'USER')
GO
/****** Object:  View [dbo].[RolesActivos]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RolesActivos]
AS
SELECT        dbo.Roles.*
FROM            dbo.Roles
WHERE        (Borrado = 0)
GO
/****** Object:  Table [dbo].[EntradasBlog]    Script Date: 20/03/2019 9:31:41 ******/
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
/****** Object:  Table [dbo].[UsuariosEntradasBlog]    Script Date: 20/03/2019 9:31:41 ******/
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

INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion], [Borrado]) VALUES (1, N'ADMIN', N'Administradores', 1)
INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion], [Borrado]) VALUES (2, N'USER', N'Usuarios', 1)
INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion], [Borrado]) VALUES (3, N'prueba', N'Prueba muy gorda', 1)
INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion], [Borrado]) VALUES (4, N'NUEVOROL', N'Descripción del rol nuevo', 1)
INSERT [dbo].[Roles] ([Id], [Rol], [Descripcion], [Borrado]) VALUES (5, N'NUEVOROL', N'Descripción del rol nuevo', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (1, 1, NULL, N'javierlete@email.net', N'contra')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (2, 2, 1, N'Yepa@email.net', N'yepa')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (3, 2, 2, N'juan@email.net', N'komomolah')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (4, 2, 2, N'pedro@email.net', N'ypa')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (8, 2, 1, N'juevo', N'yepa')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (9, NULL, NULL, N'javier@email.net', N'contra')
INSERT [dbo].[Usuarios] ([Id], [IdRol], [IdTutor], [Email], [Password]) VALUES (10, NULL, NULL, N'pepe@email.net', N'perez')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (1, 1)
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (2, 1)
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (2, 2)
INSERT [dbo].[UsuariosEntradasBlog] ([IdEntradaBlog], [IdUsuarios]) VALUES (2, 3)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_Email]    Script Date: 20/03/2019 9:31:41 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios_Email] ON [dbo].[Usuarios]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EntradasBlog] ADD  CONSTRAINT [DF_EntradaBlog_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Borrado]  DEFAULT ((0)) FOR [Borrado]
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
/****** Object:  StoredProcedure [dbo].[Bucle]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bucle]
	@inicio int, @fin int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @contador int; -- Declaración de variable local tipo int
	SET @contador = @inicio; -- Dar valor a una variable
	WHILE @contador <= @fin
	BEGIN
		PRINT @contador; -- Equivalente a WriteLine
		SET @contador = @contador + 1;
	END

	SELECT 'CONMUTA A LA VENTANA Messages'
END
GO
/****** Object:  StoredProcedure [dbo].[BuscadorPorCampoYValor]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscadorPorCampoYValor]
	@campo varchar(50),
	@valor sql_variant
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @sql nvarchar(MAX)
	SET @sql = 'SELECT Id, Email, Password FROM Usuarios WHERE ' + @campo + '=''' + CAST(@valor as nvarchar(MAX)) + '''';
	EXEC sp_executesql @sql
END
GO
/****** Object:  StoredProcedure [dbo].[ComprobarEmailYPassword]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ComprobarEmailYPassword]
	@email varchar(50), @password varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @numerofilas int
	SET @numerofilas = (SELECT COUNT(*) FROM dbo.Usuarios WHERE Email = @email AND Password = @password);

	IF @numerofilas = 1
		BEGIN
			RETURN 0;
		END
	ELSE
		BEGIN
			RETURN 1;
		END
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultaPorCampo]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultaPorCampo]
	@campo nvarchar(50),
	@valor nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @sql nvarchar(MAX)
	SET @sql = N'SELECT * FROM Usuarios WHERE ' + @campo + N'=''' + @valor + N''''

	EXEC sp_executesql @sql

END
GO
/****** Object:  StoredProcedure [dbo].[EntradasDeBlogPorUsuario]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EntradasDeBlogPorUsuario]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EntradasBlog.Titulo, EntradasBlog.Id, EntradasBlog.Texto, EntradasBlog.Fecha
	FROM Usuarios INNER JOIN
        UsuariosEntradasBlog ON Usuarios.Id = UsuariosEntradasBlog.IdUsuarios INNER JOIN
        EntradasBlog ON UsuariosEntradasBlog.IdEntradaBlog = EntradasBlog.Id
	WHERE (Usuarios.Id = 1);

SELECT * FROM Usuarios WHERE Id = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[EntradasDeBlogPorUsuarioPorId]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EntradasDeBlogPorUsuarioPorId](@IdUsuario int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EntradasBlog.Titulo, EntradasBlog.Id, EntradasBlog.Texto, EntradasBlog.Fecha
	FROM Usuarios INNER JOIN
        UsuariosEntradasBlog ON Usuarios.Id = UsuariosEntradasBlog.IdUsuarios INNER JOIN
        EntradasBlog ON UsuariosEntradasBlog.IdEntradaBlog = EntradasBlog.Id
	WHERE (Usuarios.Id = @IdUsuario);

SELECT * FROM Usuarios WHERE Id = @IdUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[InformeRolesCursores]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InformeRolesCursores]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @id int, @rol varchar(10), @descripcion nvarchar(50);

	DECLARE roles_cursor CURSOR FOR
		SELECT Id, Rol, Descripcion FROM Roles;

	OPEN roles_cursor;

	FETCH NEXT FROM roles_cursor INTO @id, @rol, @descripcion;

	IF @@FETCH_STATUS <> 0
		BEGIN
			PRINT 'NO HAY ROLES'
		END

	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT 'ID: ' + CAST(@id AS varchar) + ', ROL: ' + @rol + ', DESCRIPCIÓN: ' + @descripcion;	
		FETCH NEXT FROM roles_cursor INTO @id, @rol, @descripcion;
	END

	CLOSE roles_cursor;
	DEALLOCATE roles_cursor;

END
GO
/****** Object:  StoredProcedure [dbo].[RolesInsertar]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RolesInsertar] @Rol varchar(10), @Descripcion nvarchar(50), @Id int OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Roles (Rol, Descripcion) VALUES (@Rol, @Descripcion);
	SET @Id = (SELECT CAST(SCOPE_IDENTITY() AS int));
END
GO
/****** Object:  StoredProcedure [dbo].[UsuariosDelete]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuariosDelete]
(
	@Original_Id int,
	@IsNull_IdRol Int,
	@Original_IdRol int,
	@IsNull_IdTutor Int,
	@Original_IdTutor int,
	@Original_Email varchar(50),
	@Original_Password varchar(50)
)
AS
	SET NOCOUNT OFF;
DELETE FROM [Usuarios] WHERE (([Id] = @Original_Id) AND ((@IsNull_IdRol = 1 AND [IdRol] IS NULL) OR ([IdRol] = @Original_IdRol)) AND ((@IsNull_IdTutor = 1 AND [IdTutor] IS NULL) OR ([IdTutor] = @Original_IdTutor)) AND ([Email] = @Original_Email) AND ([Password] = @Original_Password))
GO
/****** Object:  StoredProcedure [dbo].[UsuariosInsert]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuariosInsert]
(
	@IdRol int,
	@IdTutor int,
	@Email varchar(50),
	@Password varchar(50)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [Usuarios] ([IdRol], [IdTutor], [Email], [Password]) VALUES (@IdRol, @IdTutor, @Email, @Password);
	
SELECT Id, IdRol, IdTutor, Email, Password FROM Usuarios WHERE (Id = SCOPE_IDENTITY())
GO
/****** Object:  StoredProcedure [dbo].[UsuariosSelect]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuariosSelect]
AS
	SET NOCOUNT ON;
SELECT Usuarios.* FROM Usuarios
GO
/****** Object:  StoredProcedure [dbo].[UsuariosUpdate]    Script Date: 20/03/2019 9:31:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuariosUpdate]
(
	@IdRol int,
	@IdTutor int,
	@Email varchar(50),
	@Password varchar(50),
	@Original_Id int,
	@IsNull_IdRol Int,
	@Original_IdRol int,
	@IsNull_IdTutor Int,
	@Original_IdTutor int,
	@Original_Email varchar(50),
	@Original_Password varchar(50),
	@Id int
)
AS
	SET NOCOUNT OFF;
UPDATE [Usuarios] SET [IdRol] = @IdRol, [IdTutor] = @IdTutor, [Email] = @Email, [Password] = @Password WHERE (([Id] = @Original_Id) AND ((@IsNull_IdRol = 1 AND [IdRol] IS NULL) OR ([IdRol] = @Original_IdRol)) AND ((@IsNull_IdTutor = 1 AND [IdTutor] IS NULL) OR ([IdTutor] = @Original_IdTutor)) AND ([Email] = @Original_Email) AND ([Password] = @Original_Password));
	
SELECT Id, IdRol, IdTutor, Email, Password FROM Usuarios WHERE (Id = @Id)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Roles"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RolesActivos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RolesActivos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[26] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Usuarios"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 158
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Roles"
            Begin Extent = 
               Top = 11
               Left = 302
               Bottom = 124
               Right = 472
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsuariosDeRolUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UsuariosDeRolUser'
GO
USE [master]
GO
ALTER DATABASE [ipartek] SET  READ_WRITE 
GO
