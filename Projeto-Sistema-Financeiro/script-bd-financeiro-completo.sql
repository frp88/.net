-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.4.17-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para bdfinanceiro
CREATE DATABASE IF NOT EXISTS `bdfinanceiro` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `bdfinanceiro`;

-- Copiando estrutura para tabela bdfinanceiro.tblmovimentacao
CREATE TABLE IF NOT EXISTS `tblmovimentacao` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  `datamov` date DEFAULT NULL,
  `tipomov` varchar(15) DEFAULT NULL,
  `situacao` varchar(15) DEFAULT NULL,
  `codtipopag` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_tblmov_tbltipopag` (`codtipopag`),
  CONSTRAINT `fk_tblmov_tbltipopag` FOREIGN KEY (`codtipopag`) REFERENCES `tbltipopagamento` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;

-- Exportação de dados foi desmarcado.

-- Copiando estrutura para tabela bdfinanceiro.tbltipopagamento
CREATE TABLE IF NOT EXISTS `tbltipopagamento` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `tipopagamento` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Exportação de dados foi desmarcado.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
