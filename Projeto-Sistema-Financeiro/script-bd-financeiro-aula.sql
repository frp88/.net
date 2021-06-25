CREATE TABLE tblformadepagamento(
	codigo INT PRIMARY KEY AUTO_INCREMENT, 
	formadepagamento VARCHAR(50));

INSERT INTO tblformadepagamento(formadepagamento) VALUES
('Não definida'), ('Dinheiro'), ('Transferência'), 
('Cartão de Crédito'), ('Cartão de Débito'), ('PIX'), 
('Boleto');

SELECT * FROM tblformadepagamento;	

ALTER TABLE tblmovimentacao 
ADD codformadepag INT NULL, 
ADD CONSTRAINT fk_tblmov_tblformadepag 
	FOREIGN KEY (codformadepag) 
		REFERENCES tblformadepagamento(codigo);
		
DESC tblmovimentacao;

SELECT * FROM tblmovimentacao;

UPDATE tblmovimentacao SET codformadepag = 1;
		
ALTER TABLE tblmovimentacao 
DROP CONSTRAINT fk_tblmov_tblformadepag, 
DROP codformadepag;

SELECT * FROM tblmovimentacao;

DROP TABLE tblformadepagamento;	

