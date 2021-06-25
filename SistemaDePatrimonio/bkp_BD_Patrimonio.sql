-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.27-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema patrimonio
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ patrimonio;
USE patrimonio;

--
-- Table structure for table `patrimonio`.`tblbem`
--

DROP TABLE IF EXISTS `tblbem`;
CREATE TABLE `tblbem` (
  `idBem` int(10) unsigned NOT NULL auto_increment,
  `numPatrimonio` varchar(50) default NULL,
  `descricao` varchar(100) default NULL,
  `dtCadastro` datetime default NULL,
  `dtDeposito` datetime default NULL,
  `dtBaixa` datetime default NULL,
  `motivoBaixa` varchar(500) default NULL,
  `tipo` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`idBem`),
  KEY `FK_tblBem_tblTipo` (`tipo`),
  CONSTRAINT `FK_tblBem_tblTipo` FOREIGN KEY (`tipo`) REFERENCES `tbltipo` (`idTipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patrimonio`.`tblbem`
--

/*!40000 ALTER TABLE `tblbem` DISABLE KEYS */;
INSERT INTO `tblbem` (`idBem`,`numPatrimonio`,`descricao`,`dtCadastro`,`dtDeposito`,`dtBaixa`,`motivoBaixa`,`tipo`) VALUES 
 (5,'123456','Athon X2 4GB Memoria','2011-06-28 16:43:35',NULL,NULL,NULL,1),
 (6,'NC','Multi-Funcinal Xerox','2011-06-28 17:02:53',NULL,NULL,'Produto Estragado.',3),
 (7,'54674','LG - LED','2011-06-28 17:03:31',NULL,NULL,NULL,2);
/*!40000 ALTER TABLE `tblbem` ENABLE KEYS */;


--
-- Table structure for table `patrimonio`.`tblfuncionario`
--

DROP TABLE IF EXISTS `tblfuncionario`;
CREATE TABLE `tblfuncionario` (
  `siape` varchar(30) NOT NULL,
  `Nome` varchar(50) NOT NULL,
  PRIMARY KEY  (`siape`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patrimonio`.`tblfuncionario`
--

/*!40000 ALTER TABLE `tblfuncionario` DISABLE KEYS */;
INSERT INTO `tblfuncionario` (`siape`,`Nome`) VALUES 
 ('123','Fernando Roberto Proença'),
 ('456','Ricardo Brigato Scheicher'),
 ('789','Rodrigo Fernandes Barroso');
/*!40000 ALTER TABLE `tblfuncionario` ENABLE KEYS */;


--
-- Table structure for table `patrimonio`.`tblmovimentacao`
--

DROP TABLE IF EXISTS `tblmovimentacao`;
CREATE TABLE `tblmovimentacao` (
  `idMovimentacao` int(10) unsigned NOT NULL auto_increment,
  `numeroBem` int(10) unsigned NOT NULL,
  `siapeFunc` varchar(30) NOT NULL,
  `numeroSala` int(10) unsigned NOT NULL,
  `dtRetirada` datetime default NULL,
  `dtDevolucao` datetime default NULL,
  `observacao` varchar(500) default NULL,
  PRIMARY KEY  (`idMovimentacao`),
  KEY `FK_tblSala_tblMov` (`numeroSala`),
  KEY `FK_tblFunc_tblMov` (`siapeFunc`),
  KEY `FK_tblBem_tblMov` (`numeroBem`),
  CONSTRAINT `FK_tblBem_tblMov` FOREIGN KEY (`numeroBem`) REFERENCES `tblbem` (`idBem`),
  CONSTRAINT `FK_tblFunc_tblMov` FOREIGN KEY (`siapeFunc`) REFERENCES `tblfuncionario` (`siape`),
  CONSTRAINT `FK_tblSala_tblMov` FOREIGN KEY (`numeroSala`) REFERENCES `tblsala` (`idSala`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 4096 kB';

--
-- Dumping data for table `patrimonio`.`tblmovimentacao`
--

/*!40000 ALTER TABLE `tblmovimentacao` DISABLE KEYS */;
INSERT INTO `tblmovimentacao` (`idMovimentacao`,`numeroBem`,`siapeFunc`,`numeroSala`,`dtRetirada`,`dtDevolucao`,`observacao`) VALUES 
 (1,5,'456',3,'2011-06-28 16:43:36',NULL,NULL),
 (2,6,'123',1,'2011-06-28 17:02:53','2011-06-28 23:11:47','Transferido para o Ricardo. Não utilizarei mais. Ficará Disponível para os alunos do Grupo de Pesquisa.'),
 (3,7,'789',1,'2011-06-28 17:03:31','2011-06-29 08:14:57',NULL),
 (4,6,'456',3,'2011-06-28 23:11:47',NULL,NULL),
 (5,7,'789',3,'2011-06-29 08:14:57',NULL,NULL);
/*!40000 ALTER TABLE `tblmovimentacao` ENABLE KEYS */;


--
-- Table structure for table `patrimonio`.`tblsala`
--

DROP TABLE IF EXISTS `tblsala`;
CREATE TABLE `tblsala` (
  `idSala` int(10) unsigned NOT NULL auto_increment,
  `numero` int(10) unsigned NOT NULL,
  `anexo` varchar(50) NOT NULL,
  `descricao` varchar(500) NOT NULL,
  PRIMARY KEY  (`idSala`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patrimonio`.`tblsala`
--

/*!40000 ALTER TABLE `tblsala` DISABLE KEYS */;
INSERT INTO `tblsala` (`idSala`,`numero`,`anexo`,`descricao`) VALUES 
 (1,45,'DC','Sala de Reuniões'),
 (3,15,'DC','Secretaria');
/*!40000 ALTER TABLE `tblsala` ENABLE KEYS */;


--
-- Table structure for table `patrimonio`.`tbltipo`
--

DROP TABLE IF EXISTS `tbltipo`;
CREATE TABLE `tbltipo` (
  `idTipo` int(10) unsigned NOT NULL auto_increment,
  `descricao` varchar(100) NOT NULL,
  PRIMARY KEY  (`idTipo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patrimonio`.`tbltipo`
--

/*!40000 ALTER TABLE `tbltipo` DISABLE KEYS */;
INSERT INTO `tbltipo` (`idTipo`,`descricao`) VALUES 
 (1,'Computador'),
 (2,'Monitor'),
 (3,'Impressora'),
 (4,'Scanner'),
 (5,'Cadeira'),
 (6,'Mesa');
/*!40000 ALTER TABLE `tbltipo` ENABLE KEYS */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
