-- SP Ola Mundo!!!
DELIMITER $$
CREATE PROCEDURE sp_OlaMundo()
BEGIN
	SELECT 'Olá Mundo!!!';
END $$
DELIMITER;
CALL sp_OlaMundo();

-- SP Quadrado
DELIMITER $$
CREATE PROCEDURE sp_Quadrado(IN _numero int)
BEGIN
	SELECT _numero * _numero AS Quadrado;
END $$
DELIMITER;
CALL sp_Quadrado(3);

-- SP Busca todos os funcionários
DELIMITER $$
CREATE PROCEDURE sp_BuscaFuncionarios()
BEGIN
SELECT * FROM tblfuncionario;
END $$
DELIMITER;
CALL sp_BuscaFuncionarios();

-- SP Busca funcionário pelo ID
DELIMITER $$
CREATE PROCEDURE sp_BuscaFuncionarioPeloId(_id int)
BEGIN
SELECT * FROM tblfuncionario where id = _id;
END $$
DELIMITER;
CALL sp_BuscaFuncionarioPeloId(4);

-- SP Insere funcionário
DELIMITER $$
CREATE PROCEDURE sp_InsereFuncionario(_nome varchar(50),
	_idade int, _salario float)
BEGIN
insert into tblfuncionario(nome, idade, salario) 
	values(_nome, _idade, _salario);
END $$
DELIMITER;
CALL sp_InsereFuncionario('Pedro', 45, 5000);

-- SP Atualiza funcionário
DELIMITER $$
CREATE PROCEDURE sp_AtualizaFuncionario(_nome varchar(50),
	_idade int, _salario float, _id int)
BEGIN
update tblfuncionario set nome = _nome, idade = _idade, 
		salario = _salario where id = _id;
END $$
DELIMITER;
CALL sp_AtualizaFuncionario('Pedro H.', 49, 5900, 8);

-- SP Exclui funcionário
DELIMITER $$
CREATE PROCEDURE sp_ExcluiFuncionario(_id int)
BEGIN
delete from tblfuncionario where id = _id;
END $$
DELIMITER;
CALL sp_ExcluiFuncionario(9);

CALL sp_BuscaFuncionarios();

