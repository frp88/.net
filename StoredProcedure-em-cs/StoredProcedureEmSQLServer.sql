-- Para alterar a Procedure use o comando 'ALTER'
--ALTER PROCEDURE ola AS 
--BEGIN
--	SELECT 'OLÁ MUNDO!!!'
--END
--EXECUTE ola

--CREATE PROCEDURE InsereUsuario @nome varchar(50), @login varchar(50), @senha varchar(50) AS
--BEGIN
--	INSERT INTO tblUsuario(nome, login, senha) VALUES(@nome, @login, @senha)
--END
--EXECUTE InsereUsuario 'Kauê', 'kaue', '123'
--SELECT * FROM tblUsuario

--CREATE PROCEDURE quad @num INT AS
--BEGIN
--	SELECT @num * @num AS QUADRADO
--END
--EXECUTE quad 5

--ALTER PROCEDURE RetornaUsuario @login VARCHAR(50) AS 
--BEGIN
--	SELECT * FROM tblUsuario 
--	WHERE login LIKE @login
--END
--EXECUTE RetornaUsuario 'fernando'

--CREATE PROCEDURE VerificaLogin @login VARCHAR(50) AS
--BEGIN
--	SELECT COUNT(*) AS total FROM tblUsuario
--	WHERE login LIKE @login
--END
--EXECUTE VerificaLogin 'fernando' 





--ALTER PROCEDURE ValidaUsuario @login VARCHAR(50) AS
--BEGIN
--	DECLARE @total AS INT = 0, @teste AS VARCHAR(50)
--	SET @total = (SELECT COUNT(*) FROM tblUsuario
--	WHERE login LIKE @login)
--	IF (@total > 0) 
--		SELECT 'SIM' AS usuarioValido
--	ELSE 
--		SELECT 'NAO' AS usuarioValido
--END
--EXECUTE ValidaUsuario 'fernanda' 




