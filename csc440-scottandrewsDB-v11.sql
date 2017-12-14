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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.bid: ~3 rows (approximately)
/*!40000 ALTER TABLE `bid` DISABLE KEYS */;
INSERT INTO `bid` (`Id`, `ReviewerID`, `PaperID`, `Rating`) VALUES
	(1, 8, 1, 4),
	(2, 8, 2, 4),
	(3, 8, 3, 3);
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
	(2, 'CSC Conference', 'It\'s so easy', 100, 'conf2.jpg', '2017-12-06 20:40:19', b'0'),
	(3, 'Network Conference', 'This is a fun conference.', 100, 'conf3.jpg', '2017-12-14 10:00:00', b'0'),
	(5, 'Security Conference', 'Learn about IT Security!', 100, 'conf4.jpg', '0001-01-01 08:00:00', b'0');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.papers: ~3 rows (approximately)
/*!40000 ALTER TABLE `papers` DISABLE KEYS */;
INSERT INTO `papers` (`ID`, `AuthorID`, `DocPath`, `ConfID`, `title`, `description`) VALUES
	(1, 5, 'Test_Paper1.docx', 1, 'Test_Paper1', 'This is a test paper.'),
	(2, 6, 'Test_Paper2.docx', 1, 'Test_Paper2', 'Hey this is a test paper 2.'),
	(3, 7, 'Test_Paper3.docx', 1, 'Test_Paper3', 'Hey this is a test paper 3.');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.registration: ~4 rows (approximately)
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
INSERT INTO `registration` (`RID`, `UserID`, `ConfID`, `Privilege`, `checkedin`) VALUES
	(1, 5, 1, 1, b'1'),
	(2, 6, 1, 1, b'0'),
	(3, 7, 1, 1, b'1'),
	(4, 8, 1, 2, b'0');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.reviews: ~3 rows (approximately)
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` (`ID`, `PaperID`, `Reviewer`, `PrivateComment`, `Comment`, `Completed`, `Rating`) VALUES
	(1, 1, 8, 'This is a bad paper', 'This is a good paper', b'1', 'Strongly Accept'),
	(2, 2, 8, 'NA', 'NA', b'0', 'NA'),
	(3, 3, 8, 'NA', 'NA', b'0', 'NA');
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

-- Dumping data for table csc440conferencemanagement.user: ~5 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`ID`, `email`, `Password`, `AccessLevel`, `Name`) VALUES
	(1, 'Guy', '123456', 2, 'Guy'),
	(2, 'Girl', '123456', 2, 'Girl'),
	(3, 'admin', 'admin', 3, 'admin'),
	(4, 'andy', '123456', 2, 'andy'),
	(5, '1', '123456', 2, 'bob'),
	(6, '2', '123456', 2, 'jeff'),
	(7, '3', '123456', 2, 'sally'),
	(8, '4', '123456', 2, 'tim'),
	(9, '5', '123456', 2, 'john'),
	(10, '6', '123456', 2, 'katie'),
	(11, '7', '123456', 2, 'sam');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
