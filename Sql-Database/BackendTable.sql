CREATE DATABASE BackendStoreDB;


USE BackendStoreDB;


ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF
GO

CREATE TABLE Postnummer (
	Postnummer int PRIMARY KEY,
	Bynavn varchar(75) NOT NULL
);

CREATE TABLE Adresse (
	AdresseID int IDENTITY(1,1) PRIMARY KEY,
	Postnummer int FOREIGN KEY REFERENCES Postnummer(Postnummer) NOT NULL,
	VejNavn varchar(75) NOT NULL, 
	Vejnummer varchar(75) NOT NULL
);

CREATE TABLE Butikker (
	ButikID int IDENTITY(1,1) PRIMARY KEY,
	Navn varchar(30),
	AdresseID int FOREIGN KEY REFERENCES Adresse(AdresseID) NOT NULL,
);

CREATE TABLE Kunder (
	KundeID int IDENTITY(1,1) PRIMARY KEY,
	Fornavn varchar(45) NOT NULL,
	Efternavn varchar(45) NOT NULL,
	Mobil int,
	Email varchar(45) NOT NULL,
	AdresseID FOREIGN KEY REFERENCES Adresse(AdresseID) NOT NULL,
);

CREATE TABLE MyOrdre (
 OrderID int IDENTITY(1,1) PRIMARY KEY,
 KundeID int FOREIGN KEY REFERENCES Kunder(KundeID),
 ButikID int FOREIGN KEY REFERENCES Butikker(ButikID) NOT NULL,
 OpretDate DATETIME DEFAULT GETDATE()
);


CREATE TABLE Afdelinger (
	AfdelingerID int IDENTITY(1,1) PRIMARY KEY,
	Navn varchar(46) NOT NULL,
);

CREATE TABLE Medarbejdere (
	Medarbejdere int IDENTITY(1,1) PRIMARY KEY,
	Fornavn varchar(45) NOT NULL,
	Efternavn varchar(45) NOT NULL,
	Mobil int NOT NULL,
	Email varchar(45),
	Status varchar(30) NOT NULL,
	Pay int NOT NULL,
	AdresseID int FOREIGN KEY REFERENCES Adresse(AdresseID),
	AfdelingerID int FOREIGN KEY REFERENCES Afdelinger(AfdelingerID) NOT NULL,
);



CREATE TABLE ProduktOrder (
	ProduktOrderID int IDENTITY(1,1) PRIMARY KEY,
	OrderID int FOREIGN KEY REFERENCES MyOrdre(OrderID) NOT NULL,
	ProduktID int FOREIGN KEY REFERENCES Produkt(ProduktID) NOT NULL,
	Antal int NOT NULL,
	Príse int
);


CREATE TABLE Lager (
	LagerID int IDENTITY(1,1) PRIMARY KEY,
	Antal int
);
CREATE TABLE Produkt (
	ProduktID int IDENTITY(1,1) PRIMARY KEY,
	ProduktNavn varchar(75) NOT NULL,
	Prise int NOT NULL,
);
CREATE TABLE Levering (
	LeveringID int IDENTITY(1,1) PRIMARY KEY,
	OrderID int FOREIGN KEY REFERENCES MyOrdre(OrderID) NOT NULL,
	AdresseID int FOREIGN KEY REFERENCES Adresse(AdresseID) NOT NULL,
	SendDato DATETIME
);

CREATE TABLE Lager_has_butikker (
	Lager_LagerID int FOREIGN KEY REFERENCES Lager(LagerID),
	Butikker_ButikID int FOREIGN KEY REFERENCES Butikker(ButikID)
);

CREATE TABLE Lager_has_Produkt (
	Lager_LagerID int FOREIGN KEY REFERENCES Lager(LagerID),
	Produkt_ProduktID int FOREIGN KEY REFERENCES Produkt(ProduktID)
);

CREATE TABLE Butikker_has_Afdelinger (
	Butikker_ButikID int FOREIGN KEY REFERENCES Butikker(ButikID),
	Afdelinger_AfdelingerID int FOREIGN KEY REFERENCES Afdelinger(AfdelingerID)
);