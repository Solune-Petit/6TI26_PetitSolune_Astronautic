DROP TABLE IF EXISTS Player ;
CREATE TABLE Player (playerID INT AUTO_INCREMENT NOT NULL,
playerName VARCHAR(25),
playerEmail VARCHAR(255),
playerPassword VARCHAR(16),
PRIMARY KEY (playerID)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Persos ;
CREATE TABLE Persos (persosID INT AUTO_INCREMENT NOT NULL,
persosName VARCHAR(25),
persosImg VARCHAR(30),
persosType VARCHAR(15),
persosRarete INT(5),
persosPvMax BIGINT,
persosLvlMax INT(50),
PRIMARY KEY (persosID)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Attaque ;
CREATE TABLE Attaque (attaqueID INT AUTO_INCREMENT NOT NULL,
attaqueName VARCHAR(100),
attaquePuissance INT(50),
attaqueType INT(3),
PRIMARY KEY (attaqueID)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Modificateurs ;
CREATE TABLE Modificateurs (modificateursID INT AUTO_INCREMENT NOT NULL,
modificateursName VARCHAR(30),
modificateursDescription VARCHAR(255),
modificateursDuree INT(3),
PRIMARY KEY (modificateursID)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Possede ;
CREATE TABLE Possede (PossedeID INT AUTO_INCREMENT NOT NULL,
playerID INT NOT NULL,
persosID INT NOT NULL,
possedeCoins BIGINT,
possedeGems BIGINT,
PRIMARY KEY (PossedeID)) ENGINE=InnoDB;

DROP TABLE IF EXISTS LanceAttaque ;
CREATE TABLE LanceAttaque (lanceAttaqueID INT AUTO_INCREMENT NOT NULL,
persosID INT NOT NULL,
attaqueID INT NOT NULL,
PRIMARY KEY (lanceAttaqueID)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Appliques ;
CREATE TABLE Appliques (appliquesID INT AUTO_INCREMENT NOT NULL,
attaqueID INT NOT NULL,
modificateursID INT NOT NULL,
PRIMARY KEY (appliquesID)) ENGINE=InnoDB;

ALTER TABLE possede 
	ADD CONSTRAINT `playerID` FOREIGN KEY (`playerID`) REFERENCES `astronautic`.`player` (`playerID`),
	ADD CONSTRAINT `persosID` FOREIGN KEY (`persosID`) REFERENCES `astronautic`.`persos` (`persosID`);

ALTER TABLE `astronautic`.`appliques` 
ADD CONSTRAINT `attaqueID`
  FOREIGN KEY (`attaqueID`)
  REFERENCES `astronautic`.`attaque` (`attaqueID`),
ADD CONSTRAINT `modificateursID`
  FOREIGN KEY (`modificateursID`)
  REFERENCES `astronautic`.`modificateurs` (`modificateursID`);

ALTER TABLE `astronautic`.`lanceattaque` 
	ADD CONSTRAINT `persosID` FOREIGN KEY (`persosID`) REFERENCES `astronautic`.`persos` (`persosID`),
	ADD CONSTRAINT `attaqueID` FOREIGN KEY (`attaqueID`) REFERENCES `astronautic`.`appliques` (`attaqueID`);
