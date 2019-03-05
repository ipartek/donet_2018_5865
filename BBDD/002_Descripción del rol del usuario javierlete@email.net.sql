SELECT Descripcion
FROM Roles, Usuarios
WHERE Email = 'javierlete@email.net' AND Roles.Id = Usuarios.IdRol;

SELECT Descripcion
FROM Usuarios
INNER JOIN Roles ON Roles.Id = Usuarios.IdRol
WHERE Email = 'javierlete@email.net';