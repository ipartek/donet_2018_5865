SELECT Email
FROM Usuarios
WHERE Id = (
	SELECT IdTutor
	FROM Usuarios
	WHERE Email = 'pepe@email.net');

SELECT uTutores.Email
FROM Usuarios uTutores, Usuarios uUsuarios
WHERE uTutores.Id = uUsuarios.IdTutor AND uUsuarios.Email = 'pepe@email.net';

SELECT uTutores.Email
FROM Usuarios uUsuarios
INNER JOIN Usuarios uTutores ON uTutores.Id = uUsuarios.IdTutor
WHERE uUsuarios.Email = 'pepe@email.net';