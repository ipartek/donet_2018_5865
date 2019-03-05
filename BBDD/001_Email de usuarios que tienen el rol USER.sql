SELECT Email
FROM Roles, Usuarios
WHERE Rol = 'USER' AND Roles.Id = Usuarios.IdRol;

SELECT Email
FROM Roles
INNER JOIN Usuarios ON Roles.Id = Usuarios.IdRol
WHERE Rol = 'USER';