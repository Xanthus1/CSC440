-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.28-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for csc440conferencemanagement
CREATE DATABASE IF NOT EXISTS `csc440conferencemanagement` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `csc440conferencemanagement`;

-- Dumping structure for table csc440conferencemanagement.alerts
CREATE TABLE IF NOT EXISTS `alerts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userID` int(11) DEFAULT NULL,
  `alertMsg` varchar(100) DEFAULT NULL,
  `viewed` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_user` (`userID`),
  CONSTRAINT `fk_user` FOREIGN KEY (`userID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Alert table for users';

-- Dumping data for table csc440conferencemanagement.alerts: ~0 rows (approximately)
/*!40000 ALTER TABLE `alerts` DISABLE KEYS */;
/*!40000 ALTER TABLE `alerts` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.bid
CREATE TABLE IF NOT EXISTS `bid` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ReviewerID` int(11) DEFAULT NULL,
  `PaperID` int(11) DEFAULT NULL,
  `Rating` int(5) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Bid_user` (`ReviewerID`),
  KEY `FK_Bid_papers` (`PaperID`),
  CONSTRAINT `FK_Bid_papers` FOREIGN KEY (`PaperID`) REFERENCES `papers` (`ID`),
  CONSTRAINT `FK_Bid_user` FOREIGN KEY (`ReviewerID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.bid: ~7 rows (approximately)
/*!40000 ALTER TABLE `bid` DISABLE KEYS */;
INSERT INTO `bid` (`Id`, `ReviewerID`, `PaperID`, `Rating`) VALUES
	(1, 5, 16, 5),
	(2, 5, 17, 4),
	(3, 5, 18, 3),
	(4, 5, 19, 2),
	(5, 5, 20, 1),
	(6, 5, 21, 1),
	(7, 5, 22, 5),
	(8, 2, 24, 5),
	(9, 6, 25, 4);
/*!40000 ALTER TABLE `bid` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.conference
CREATE TABLE IF NOT EXISTS `conference` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` tinytext,
  `PaperLimit` int(11) DEFAULT NULL,
  `ImagePath` tinytext,
  `DateTime` datetime DEFAULT NULL,
  `reviewPhase` bit(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.conference: ~4 rows (approximately)
/*!40000 ALTER TABLE `conference` DISABLE KEYS */;
INSERT INTO `conference` (`ID`, `Name`, `Description`, `PaperLimit`, `ImagePath`, `DateTime`, `reviewPhase`) VALUES
	(1, 'Math Con', 'Math conference for all ages', 100, 'conf1.jpg', '2017-12-06 20:40:17', b'1'),
	(2, 'CSC Conference', 'It\'s so easy', 100, 'conf2.jpg', '2017-12-06 20:40:19', b'1'),
	(3, 'New Conference', 'Admin added conference', 100, 'CSC 440 - Class Diagram v2.jpg', '2017-12-14 10:00:00', b'0'),
	(5, 'New conference', 'test', 100, 'IMG_20171120_202612.jpg', '0001-01-01 08:00:00', b'1');
/*!40000 ALTER TABLE `conference` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.papers
CREATE TABLE IF NOT EXISTS `papers` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `AuthorID` int(11) DEFAULT NULL,
  `DocPath` tinytext,
  `ConfID` int(11) DEFAULT NULL,
  `title` varchar(50) DEFAULT NULL,
  `description` text,
  PRIMARY KEY (`ID`),
  KEY `PaperConfID` (`ConfID`),
  KEY `fk_AuthorID` (`AuthorID`),
  CONSTRAINT `PaperConfID` FOREIGN KEY (`ConfID`) REFERENCES `conference` (`ID`),
  CONSTRAINT `fk_AuthorID` FOREIGN KEY (`AuthorID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.papers: ~8 rows (approximately)
/*!40000 ALTER TABLE `papers` DISABLE KEYS */;
INSERT INTO `papers` (`ID`, `AuthorID`, `DocPath`, `ConfID`, `title`, `description`) VALUES
	(16, 1, 'cmdb_documentation (1).docx', 5, 'cmdb_documentation (1)', 'awdawdawdawdwad'),
	(17, 2, 'cmdb_documentation (2).docx', 5, 'cmdb_documentation (2)', '12345613'),
	(18, 6, 'burden_csc547_hw4.docx', 5, 'burden_csc547_hw4', '123451'),
	(19, 7, 'burden_csc547_hw4 (1).docx', 5, 'burden_csc547_hw4 (1)', 'test'),
	(20, 8, 'cmdb_documentation (3) (1) (1).docx', 5, 'cmdb_documentation (3) (1) (1)', '1qadwdawd'),
	(21, 9, 'cmdb_documentation (3) (1).docx', 5, 'cmdb_documentation (3) (1)', 'adwdawd'),
	(22, 10, 'cmdb_documentation (1) (1).docx', 5, 'cmdb_documentation (1) (1)', ''),
	(23, 11, 'cmdb_documentation (2) (1).docx', 5, 'cmdb_documentation (2) (1)', 'adwad'),
	(24, 5, 'burden_csc547_hw4 (1).docx', 1, 'burden_csc547_hw4 (1)', 'adaawdd'),
	(25, 5, 'cmdb_documentation.docx', 2, 'cmdb_documentation', 'awdawd');
/*!40000 ALTER TABLE `papers` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.registration
CREATE TABLE IF NOT EXISTS `registration` (
  `RID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `ConfID` int(11) DEFAULT NULL,
  `Privilege` int(3) DEFAULT NULL,
  `checkedin` bit(1) DEFAULT NULL,
  PRIMARY KEY (`RID`),
  KEY `UserID` (`UserID`),
  KEY `ConfID` (`ConfID`),
  CONSTRAINT `ConfID` FOREIGN KEY (`ConfID`) REFERENCES `conference` (`ID`),
  CONSTRAINT `UserID` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.registration: ~8 rows (approximately)
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` (`RID`, `UserID`, `ConfID`, `Privilege`, `checkedin`) VALUES
	(27, 1, 5, 1, b'0'),
	(28, 2, 5, 1, b'0'),
	(29, 5, 5, 2, b'0'),
	(30, 6, 5, 1, b'0'),
	(31, 7, 5, 1, b'0'),
	(32, 7, 5, 1, b'0'),
	(33, 8, 5, 1, b'0'),
	(34, 9, 5, 1, b'0'),
	(35, 10, 5, 1, b'0'),
	(36, 11, 5, 1, b'0'),
	(41, 5, 1, 1, b'1'),
	(42, 1, 1, 2, b'0'),
	(43, 2, 1, 2, b'1'),
	(44, 5, 2, 1, b'0'),
	(45, 6, 2, 2, b'0');
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.reviews
CREATE TABLE IF NOT EXISTS `reviews` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PaperID` int(11) DEFAULT NULL,
  `Reviewer` int(11) DEFAULT NULL,
  `PrivateComment` text,
  `Comment` text,
  `Completed` bit(1) DEFAULT NULL,
  `Rating` text,
  PRIMARY KEY (`ID`),
  KEY `PaperID` (`PaperID`),
  CONSTRAINT `PaperID` FOREIGN KEY (`PaperID`) REFERENCES `papers` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.reviews: ~7 rows (approximately)
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` (`ID`, `PaperID`, `Reviewer`, `PrivateComment`, `Comment`, `Completed`, `Rating`) VALUES
	(1, 16, 5, 'NA', 'NA', b'0', 'NA'),
	(2, 17, 5, 'NA', 'NA', b'0', 'NA'),
	(3, 18, 5, 'NA', 'NA', b'0', 'NA'),
	(4, 19, 5, 'adwadawd', 'adwqwd', b'1', 'Accept'),
	(5, 20, 5, 'NA', 'NA', b'0', 'NA'),
	(6, 21, 5, 'NA', 'NA', b'0', 'NA'),
	(7, 22, 5, 'NA', 'NA', b'0', 'NA'),
	(8, 24, 2, 'awawdawd', '1111', b'1', 'Strongly Accept'),
	(9, 25, 6, '123', '1', b'1', 'Neutral');
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.user
CREATE TABLE IF NOT EXISTS `user` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `email` varchar(50) NOT NULL DEFAULT 'email@gmail.com',
  `Password` varchar(50) NOT NULL,
  `AccessLevel` int(3) NOT NULL,
  `Name` varchar(70) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.user: ~11 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`ID`, `email`, `Password`, `AccessLevel`, `Name`) VALUES
	(1, 'Guy', '123456', 2, 'Guy'),
	(2, 'Girl', '123456', 2, 'Girl'),
	(3, 'admin', 'admin', 3, 'admin'),
	(4, 'andy', '123456', 2, 'andy'),
	(5, '1', '123456', 2, '1'),
	(6, '2', '123456', 2, 'BOB'),
	(7, '3', '123456', 2, 'john'),
	(8, '4', '123456', 2, '4'),
	(9, '5', '123456', 2, '5'),
	(10, '6', '123456', 2, '6'),
	(11, '7', '123456', 2, '7');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
