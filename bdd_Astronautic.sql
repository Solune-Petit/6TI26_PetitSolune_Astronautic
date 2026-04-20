#Creation des tables

DROP TABLE IF EXISTS Personnage ;
CREATE TABLE Personnage (PersonnageId INT AUTO_INCREMENT NOT NULL,
PersonnageNom VARCHAR(25),
PersonnageImg VARCHAR(25),
PersonnageType VARCHAR(25),
PersonnageRarete INT(5),
PersonnagePvMax INT,
PersonnageLvlMax INT(50),
PRIMARY KEY (PersonnageId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Attaque ;
CREATE TABLE Attaque (AttaqueId INT AUTO_INCREMENT NOT NULL,
AttaqueNom VARCHAR(40),
AttaquePuissance INT(50),
AttaqueDescription VARCHAR(255),
Role INT(3),
ModifyersId INT NOT NULL,
PRIMARY KEY (AttaqueId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS User ;
CREATE TABLE User (UserId INT AUTO_INCREMENT NOT NULL,
UserName VARCHAR(16),
UserPassword VARCHAR(30),
UserMail VARCHAR(255),
UserUserItemId INT NULL,
PRIMARY KEY (UserId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS UserItem ;
CREATE TABLE UserItem (UserItemId INT AUTO_INCREMENT NOT NULL,
UserItemMoney BIGINT,
UserItemCrystal BIGINT,
UserItemUpgradeAbility BIGINT,
UserItemPersonnagesId INT NULL,
UserItemPersonnagesId VARCHAR(20),
PRIMARY KEY (UserItemId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Modifyer ;
CREATE TABLE Modifyer (ModifyerId INT AUTO_INCREMENT NOT NULL,
ModifyerNom VARCHAR(25),
ModifyerDescription VARCHAR(255),
ModifyerDuree INT(3),
ModifyerImage VARCHAR(255),
PRIMARY KEY (ModifyerId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Possede ;
CREATE TABLE Possede (PossedeId INT AUTO_INCREMENT NOT NULL,
AttaqueId INT NOT NULL,
PersonnageId INT NOT NULL,
PRIMARY KEY (PossedeId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS EstDeNiv ;
CREATE TABLE EstDeNiv (EstDeNivId INT AUTO_INCREMENT NOT NULL,
UserItemId INT NOT NULL,
PersonnagesId INT NOT NULL,
Niveau INT(50),
PRIMARY KEY (EstDeNivId)) ENGINE=InnoDB;

DROP TABLE IF EXISTS Appartiens ;
CREATE TABLE Appartiens (AppartiensId INT AUTO_INCREMENT NOT NULL,
ItemId INT NOT NULL,
UserId INT NOT NULL,
PRIMARY KEY (AppartiensId)) ENGINE=InnoDB;


#Ajout des Foreign keys
ALTER TABLE Possede ADD CONSTRAINT AttaqueId FOREIGN KEY (AttaqueId) REFERENCES Attaque (AttaqueId);
ALTER TABLE Possede ADD CONSTRAINT PersonnageId FOREIGN KEY (PersonnageId) REFERENCES Personnage (PersonnageId);
ALTER TABLE estdeniv ADD CONSTRAINT PersonnagesId FOREIGN KEY (PersonnagesId) REFERENCES personnage (PersonnageId);
ALTER TABLE EstDeNiv ADD CONSTRAINT UserItemId FOREIGN KEY (UserItemId) REFERENCES UserItem (UserItemId);
ALTER TABLE Appartiens ADD CONSTRAINT UserId FOREIGN KEY (UserId) REFERENCES User (UserId);
ALTER TABLE Appartiens ADD CONSTRAINT ItemId FOREIGN KEY (ItemId) REFERENCES UserItem (UserItemId);
ALTER TABLE Attaque ADD CONSTRAINT ModifyersId FOREIGN KEY (ModifyersId) REFERENCES modifyer (modifyerId);
ALTER TABLE useritem ADD CONSTRAINT UserItemPersonnageId FOREIGN KEY (UserItemPersonnagesId) REFERENCES personnage (PersonnageId);
ALTER TABLE user ADD CONSTRAINT UserUserItemId FOREIGN KEY (UserUserItemId) REFERENCES useritem (UserItemId);



#remplissage

#Personnages
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Daniellou', 'Mastu.jpg', 'Attaquant', '1', '100', '50');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Charles_Leclerc', 'Charles_Leclerc.jpg', 'Support', '2', '250', '40');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Amixem', 'Amixem.jpg', 'Healer', '3', '500', '30');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Teddy Rinner', 'Teddy_riner.jpg', 'Tank', '4', '1000', '20');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Supper Konar', 'Super_konar.jpg', 'Attaquant', '5', '2500', '10');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Michou', 'Michou.jpg', 'Attaquant', '1', '100', '50');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Obelgix', 'Obelgix.jpg', 'Tank', '2', '250', '40');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Pikachou', 'Pikachou.jpg', 'Healer', '3', '500', '30');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('Les Lebruns', 'Freres_Lebruns.jpg', 'Support', '4', '1000', '20');
INSERT INTO `personnage` (`PersonnageNom`, `PersonnageImg`, `PersonnageType`, `PersonnageRarete`, `PersonnagePvMax`, `PersonnageLvlMax`) VALUES ('MrBeast', 'MrBeast.jpg', 'Healer', '5', '2500', '10');


#Modifyers
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Exposition', 'l\'ennemi prendra plus de dégats', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Stun', 'L\'ennemi ne pourra pas attaquer', '2');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Weakness', 'L\'ennemi aura plus de facilité à subir des malus', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Slowed', 'L\'ennemi attaquera moins fort', '2');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Debuff', 'L\'ennemi perd toute ses modifiyers', '2');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Entrave', 'Ne pourra pas utiliser ses capacités spéciales', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Incontournable', 'L\'ennemu ne pourra pas esquiver la prochaine attaque', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Tanking', 'Les adversaires attaqueront le personnage avec l\'effet actif', '3');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Heal', 'A la fin du tour du personnage, celui-ci se soignes (15% des Pv actuels)', '0');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Shield', 'Les personnages gagneront un bouclier (-30% de dégats)', '2');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Invisibilité', 'Les personnages sont invisibles (sauf si tanking actif)', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Anti Debuff', 'les personnages auront une résistance aux malus', '2');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Contre Attaque', 'Les personnages pourront contre-attaquer s\'il n\'ont pas esquivé l\'attaque', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Invincible', 'Ne subis ni dégats, ni malus', '1');
INSERT INTO `modifyer` (`ModifyerNom`, `ModifyerDescription`, `ModifyerDuree`) VALUES ('Rien', 'N\'appliques aucun dégats', '0');

#Attaques
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('10', '1', '1', 'infliges exposition', 't\'es gros naze');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('15', '2', '11', 'Confère Invisibilité', 'Cape du bataillon d\'exploration');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('20', '3', '13', 'Confère Contre Attaque', 'Crazy Town');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('20', '1', '12', 'Se soignes et confère anti debuff à un alié de son choix', 'BoxBox');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('120', '2', '2', 'Se stun lui même', 'I am stupid');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('40', '3', '12', 'Attaque un ennemi et dissipes ses effets négatifs', 'Siège plein d\'eau');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('30', '1', '9', 'Se soignes', 'Clap Bonjour');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('45', '2', '14', 'Confère invincibilité à tous', 'Red Box');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('60', '3', '1', 'Infliges exposition à l\'énnemi', '1000 couches de béton');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('40', '1', '6', 'Attaque un ennemi et confères entrave à l\'adversaire', 'Prise de judo');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('60', '2', '2', 'Stun l\'enemi attaqué', 'Finale des J.O');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('80', '3', '8', 'Attaque un ennemi et se confère Tanking', 'Uchi mata');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('50', '1', '12', 'Attaque l\'ennemi et confère anti-buff à l\'adversaire', 'kikikikikiki');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('75', '2', '4', 'Attaque l\'ennemi et confère Slowed à l\'adversaire', 'Ein Grenade');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('100', '3', '6', 'Attaque l\'ennemi et confère Entrave à l\'adversaire', 'Le st coquelicot');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('10', '1', '8', 'Attaque l\'ennemi et confère Tanking à l\'ennemi', 'Tripple edit fortnite');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('15', '2', '6', 'Attaque l\'ennemi et confère Entrave à l\'ennemi', 'Frappe de swiss ball');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('20', '3', '11', 'Attaque l\'ennemi et confère Invisibilité à un alié au choix', 'Team Crouton');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('20', '1', '2', 'Attaque l\'ennemi et confère Stun à l\'ennemi', 'Photo fans');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('30', '2', '8', 'Attaque l\'ennmei et confère Tanking à sois même', 'La remountada');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('40', '3', '14', 'Attaque l\'ennemi et confère Invincibilité à sois même', 'Bierre');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('30', '1', '5', 'Attaque l\'ennemi et confère Debuff à l\'ennemi', 'Voltage eclatant');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('45', '2', '15', 'Attaque l\'ennemi et lui vole sa vie pour la donner à un allié au choix', 'Defibrilateur');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('60', '3', '13', 'Attaque l\'ennemi et confère Contre Attaque à un allié au choix', 'Pika Pika');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('40', '1', '7', 'Attaque l\'ennemi et confère Incontournable', 'Double smatch');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('60', '2', '8', 'Attaque l\'ennemi et confère Tanking à un ennemi aléatoire', 'Vendange fort boyard');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('80', '3', '15', 'Attaque toute la team adverse', 'Prise porte plume');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('50', '1', '3', 'Attaque l\'ennemi et confère Weakness', 'Hitman engagé');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('75', '2', '9', 'Attaque l\'ennemi et confère Heal à un allié au choix', 'Remède à 1.000.000$');
INSERT INTO `attaque` (`AttaquePuissance`, `Role`, `ModifyersId`, `AttaqueDescription`, `AttaqueNom`) VALUES ('100', '3', '6', 'Attaque l\'ennemi et confère Entrave à toute la team adverse', 'Red Light');


#possede
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('1', '1');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('2', '1');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('3', '1');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('4', '2');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('5', '2');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('6', '2');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('7', '3');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('8', '3');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('9', '3');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('10', '4');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('11', '4');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('12', '4');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('13', '5');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('14', '5');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('15', '5');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('16', '6');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('17', '6');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('18', '6');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('19', '7');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('20', '7');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('21', '7');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('22', '8');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('23', '8');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('24', '8');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('25', '9');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('26', '9');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('27', '9');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('28', '10');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('29', '10');
INSERT INTO `possede` (`AttaqueId`, `PersonnageId`) VALUES ('30', '10');