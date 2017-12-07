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
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.bid: ~0 rows (approximately)
/*!40000 ALTER TABLE `bid` DISABLE KEYS */;
REPLACE INTO `bid` (`Id`, `ReviewerID`, `PaperID`, `Rating`) VALUES
	(13, 1, 2, 5);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.conference: ~2 rows (approximately)
/*!40000 ALTER TABLE `conference` DISABLE KEYS */;
REPLACE INTO `conference` (`ID`, `Name`, `Description`, `PaperLimit`, `ImagePath`, `DateTime`, `reviewPhase`) VALUES
	(1, 'Math Con', 'Math conference for all ages', 1, 'here', '2017-12-06 20:40:17', b'0'),
	(2, 'CSC Conference', 'It\'s so easy', 1, 'here', '2017-12-06 20:40:19', b'0'),
	(3, 'New Conference', 'Admin added conference', 0, 'CSC 440 - Class Diagram v2.jpg', '2017-12-14 10:00:00', b'0');
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.papers: ~3 rows (approximately)
/*!40000 ALTER TABLE `papers` DISABLE KEYS */;
REPLACE INTO `papers` (`ID`, `AuthorID`, `DocPath`, `ConfID`, `title`, `description`) VALUES
	(1, 1, 'hispaper.doc', 1, 'HisPaper', 'The paper'),
	(2, 2, 'herpaper.doc', 1, 'HerPaper', 'Her Paper description'),
	(8, 1, 'hiscscpaper.doc', 2, 'His CSC Paper', 'The best CSC Paper');
/*!40000 ALTER TABLE `papers` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.registration
CREATE TABLE IF NOT EXISTS `registration` (
  `RID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `ConfID` int(11) DEFAULT NULL,
  `Privelage` int(3) DEFAULT NULL,
  PRIMARY KEY (`RID`),
  KEY `UserID` (`UserID`),
  KEY `ConfID` (`ConfID`),
  CONSTRAINT `ConfID` FOREIGN KEY (`ConfID`) REFERENCES `conference` (`ID`),
  CONSTRAINT `UserID` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.registration: ~0 rows (approximately)
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.reviews
CREATE TABLE IF NOT EXISTS `reviews` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PaperID` int(11) DEFAULT NULL,
  `Reviewer` varchar(70) DEFAULT NULL,
  `PrivateComment` text,
  `Comment` text,
  `Completed` bit(1) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PaperID` (`PaperID`),
  CONSTRAINT `PaperID` FOREIGN KEY (`PaperID`) REFERENCES `papers` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.reviews: ~0 rows (approximately)
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.user: ~2 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
REPLACE INTO `user` (`ID`, `email`, `Password`, `AccessLevel`, `Name`) VALUES
	(1, 'Guy', '123456', 2, 'Guy'),
	(2, 'Girl', '123456', 2, 'Girl'),
	(3, 'admin', 'admin', 3, 'admin');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
