SELECT        TOP (200) Roles.Rol, EntradasBlog.Titulo, EntradasBlog.Texto, EntradasBlog.Fecha, Usuarios.Email
FROM            Usuarios INNER JOIN
                         Roles ON Usuarios.IdRol = Roles.Id INNER JOIN
                         UsuariosEntradasBlog ON Usuarios.Id = UsuariosEntradasBlog.IdUsuarios INNER JOIN
                         EntradasBlog ON UsuariosEntradasBlog.IdEntradaBlog = EntradasBlog.Id
WHERE        (Roles.Rol = 'USER')
