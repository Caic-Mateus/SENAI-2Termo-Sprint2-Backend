-- DQL

USE inlock_games_tarde;

SELECT * FROM usuarios;
GO

SELECT * FROM estudios;
GO

SELECT * FROM jogos;

SELECT nomeJogo, nomeEstudio FROM jogos
INNER JOIN estudios
ON jogos.idEstudio = estudios.idEstudio;

SELECT nomeEstudio, nomeJogo FROM estudios
LEFT JOIN jogos
ON estudios.idEstudio = jogos.idEstudio;

SELECT email,senha, idUsuario, idTipoUsuario FROM usuarios 
WHERE email = 'admin@admin.com' AND senha = 'admin';

SELECT idJogo,nomeJogo, descricao, valor, dataLancamento FROM jogos
WHERE idJogo = 1;

SELECT idEstudio ,nomeEstudio FROM estudios
WHERE idEstudio = 2;

