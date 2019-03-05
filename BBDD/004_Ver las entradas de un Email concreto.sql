SELECT EntradasBlog.Titulo, EntradasBlog.Texto, EntradasBlog.Fecha
FROM Usuarios, UsuariosEntradasBlog, EntradasBlog
WHERE 
	Usuarios.Id = UsuariosEntradasBlog.IdUsuarios AND
	UsuariosEntradasBlog.IdEntradaBlog = EntradasBlog.Id AND
	Email='javierlete@email.net';

SELECT EntradasBlog.Titulo, EntradasBlog.Texto, EntradasBlog.Fecha
FROM Usuarios
INNER JOIN UsuariosEntradasBlog ON Usuarios.Id = UsuariosEntradasBlog.IdUsuarios
INNER JOIN EntradasBlog ON UsuariosEntradasBlog.IdEntradaBlog = EntradasBlog.Id
WHERE Email='javierlete@email.net';
