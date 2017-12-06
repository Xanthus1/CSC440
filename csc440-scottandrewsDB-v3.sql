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

-- Dumping structure for table csc440conferencemanagement.conference
CREATE TABLE IF NOT EXISTS `conference` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Description` tinytext,
  `PaperLimit` int(11) DEFAULT NULL,
  `ImagePath` tinytext,
  `DateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.conference: ~2 rows (approximately)
/*!40000 ALTER TABLE `conference` DISABLE KEYS */;
REPLACE INTO `conference` (`ID`, `Name`, `Description`, `PaperLimit`, `ImagePath`, `DateTime`) VALUES
	(1, 'Test Conference', 'The Best', 3, '/Here', '2017-12-05 15:04:02'),
	(2, 'Another Conference', 'The worst', 5, '/There', '2017-12-05 15:04:18');
/*!40000 ALTER TABLE `conference` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.papers
CREATE TABLE IF NOT EXISTS `papers` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `DocPath` tinytext,
  `AuthorID` int(11) DEFAULT NULL,
  `ConfID` int(11) DEFAULT NULL,
  `title` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `PaperConfID` (`ConfID`),
  KEY `fk_AuthorID` (`AuthorID`),
  CONSTRAINT `PaperConfID` FOREIGN KEY (`ConfID`) REFERENCES `conference` (`ID`),
  CONSTRAINT `fk_AuthorID` FOREIGN KEY (`AuthorID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.papers: ~1 rows (approximately)
/*!40000 ALTER TABLE `papers` DISABLE KEYS */;
REPLACE INTO `papers` (`ID`, `DocPath`, `AuthorID`, `ConfID`, `title`) VALUES
	(10, 'TestDoc.docx', 6, 2, 'Another Conference');
/*!40000 ALTER TABLE `papers` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.registration
CREATE TABLE IF NOT EXISTS `registration` (
  `RID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `ConfID` int(11) DEFAULT NULL,
  `Privilege` int(3) DEFAULT NULL,
  `checkedIn` bit(1) DEFAULT NULL,
  PRIMARY KEY (`RID`),
  KEY `UserID` (`UserID`),
  KEY `ConfID` (`ConfID`),
  CONSTRAINT `ConfID` FOREIGN KEY (`ConfID`) REFERENCES `conference` (`ID`),
  CONSTRAINT `UserID` FOREIGN KEY (`UserID`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.registration: ~2 rows (approximately)
/*!40000 ALTER TABLE `registration` DISABLE KEYS */;
REPLACE INTO `registration` (`RID`, `UserID`, `ConfID`, `Privilege`, `checkedIn`) VALUES
	(2, 6, 1, 2, b'1'),
	(3, 6, 2, 2, b'1');
/*!40000 ALTER TABLE `registration` ENABLE KEYS */;

-- Dumping structure for table csc440conferencemanagement.reviews
CREATE TABLE IF NOT EXISTS `reviews` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PaperID` int(11) DEFAULT NULL,
  `Reviewer` varchar(70) DEFAULT NULL,
  `PrivateComment` text,
  `Comment` text,
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
  UNIQUE KEY `Password` (`Password`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- Dumping data for table csc440conferencemanagement.user: ~2 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
REPLACE INTO `user` (`ID`, `email`, `Password`, `AccessLevel`, `Name`) VALUES
	(6, 'scott@gmail.com', '123456', 2, 'Scott'),
	(7, 'admin', 'admin', 3, 'Admin');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
