CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE Funcionarios
(
		idFuncionario INT PRIMARY KEY IDENTITY
		,Nome VARCHAR(30) NOT NULL
		,Sobrenome VARCHAR(30) NOT NULL
);