CREATE TABLE `solune`.`personnages` (
  `idPersonnages` INT NOT NULL AUTO_INCREMENT,
  `PersonnagesNom` VARCHAR(45) NOT NULL,
  `PersonnagesImage` VARCHAR(45) NOT NULL,
  `PersonnagesRole` VARCHAR(45) NOT NULL,
  `PersonnagesRarete` INT NOT NULL,
  `PersonnagesMaxPV` INT NOT NULL,
  `PersonnagesNivMax` INT NOT NULL,
  `PersonnagesAttacPrim` VARCHAR(45) NOT NULL,
  `PersonnagesAttacPrimPuiss` INT NOT NULL,
  `PersonnagesAttacSec1` VARCHAR(45) NOT NULL,
  `PersonnagesAttacSec1Puiss` INT NOT NULL,
  `PersonnagesAttacSec2` VARCHAR(45) NOT NULL,
  `PersonnagesAttacSec2Puiss` INT NOT NULL,
  PRIMARY KEY (`idPersonnages`));

INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Daniellou', 'Daniellou.jpg', 'Attaquant', '1', '100', '50', 'T\'es un gros naze', '10', 'Cape du battaillon d\'exploration', '10', 'Crazy town', '10');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Charles Leclerc', 'Charles_Leclerc.jpg', 'Support', '2', '250', '40', 'Box Box', '20', 'I am stupid', '20', 'Siège d\'eau', '20');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Amixem', 'Amixem.jpg', 'Healer', '3', '500', '30', 'Clap Bonjour', '30', 'Red Box', '30', '1000 couches', '30');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Teddy Rinner', 'Teddy_riner.jpg', 'Tank', '4', '1000', '20', 'Prise de Judo', '40', 'Finale des J.O.', '40', 'Guram Tushishvili', '40');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Supper Konar', 'Super_konar.jpg', 'Attaquant', '5', '2500', '10', 'ki ki ki ki ki ki ki ki ki', '50', 'Ein grenade', '50', 'Le st Coquelicot', '50');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Michou', 'Michou.jpg', 'Attaquant', '1', '100', '50', 'Tripple édit fortnite', '10', 'Frappe de swiss ball', '10', 'La team crouton', '10');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Obelgix', 'Obelgix.jpg', 'Tank', '2', '250', '40', 'Photo avec les fans', '20', 'La remountada', '20', 'Bière', '20');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Pikachu', 'Pikachu.jpg', 'Healer', '3', '500', '30', 'Voltage éclatant', '30', 'Défibrilateur', '30', 'Pika Pika', '30');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('Les frères Lebruns', 'Freres_Lebruns.jpg', 'support', '4', '1000', '20', 'Double smatch', '40', 'La Vidange de Fort Boyard', '40', 'La prise porte-plume', '40');
INSERT INTO `solune`.`personnages` (`PersonnagesNom`, `PersonnagesImage`, `PersonnagesRole`, `PersonnagesRarete`, `PersonnagesMaxPV`, `PersonnagesNivMax`, `PersonnagesAttacPrim`, `PersonnagesAttacPrimPuiss`, `PersonnagesAttacSec1`, `PersonnagesAttacSec1Puiss`, `PersonnagesAttacSec2`, `PersonnagesAttacSec2Puiss`) VALUES ('MrBeast', 'mrBeast.jpg', 'Healer', '5', '2500', '10', 'Hitman payé', '50', 'remède à 1 million de $', '50', 'Red light', '50');

ALTER TABLE `solune`.`personnages` 
CHANGE COLUMN `PersonnagesNom` `personnagesNom` VARCHAR(45) NOT NULL ,
CHANGE COLUMN `PersonnagesRole` `personnagesRole` VARCHAR(45) NOT NULL ,
CHANGE COLUMN `PersonnagesRarete` `personnagesRarete` INT NOT NULL ,
CHANGE COLUMN `PersonnagesMaxPV` `personnagesMaxPV` INT NOT NULL ,
CHANGE COLUMN `PersonnagesNivMax` `personnagesNivMax` INT NOT NULL ,
CHANGE COLUMN `PersonnagesAttacPrim` `personnagesAttacPrim` VARCHAR(45) NOT NULL ,
CHANGE COLUMN `PersonnagesAttacPrimPuiss` `personnagesAttacPrimPuiss` INT NOT NULL ,
CHANGE COLUMN `PersonnagesAttacSec1` `personnagesAttacSec1` VARCHAR(45) NOT NULL ,
CHANGE COLUMN `PersonnagesAttacSec1Puiss` `personnagesAttacSec1Puiss` INT NOT NULL ,
CHANGE COLUMN `PersonnagesAttacSec2` `personnagesAttacSec2` VARCHAR(45) NOT NULL ,
CHANGE COLUMN `PersonnagesAttacSec2Puiss` `personnagesAttacSec2Puiss` INT NOT NULL ;

CREATE TABLE `solune`.`personnagedescriptionetbuffdebuff` (
  `idpersonnageDescriptionEtBuffDebuff` INT NOT NULL AUTO_INCREMENT,
  `personnagedescriptionbuffdebuffDescriptionAttacPrim` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffAttacPrimBuff` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffAttacPrimDebuff` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffDescriptionAttacSec1` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffBuffAttacPrim` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffDebuffAttacSec1` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffDescriptionAttacSec2` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffBuffAttacSec2` VARCHAR(255) NOT NULL,
  `personnagedescriptionbuffdebuffDebuffAttacSec2` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`idpersonnageDescriptionEtBuffDebuff`));

ALTER TABLE `solune`.`personnagedescriptionetbuffdebuff`
ADD COLUMN `idPersonnage` INT NOT NULL,
ADD CONSTRAINT fk_personnage_id FOREIGN KEY (`idPersonnage`) REFERENCES `solune`.`personnages`(`idPersonnages`);
