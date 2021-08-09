CREATE DATABASE BackendStoreDB;


USE BackendStoreDB;


ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF
GO

CREATE TABLE Postnummer (
	Postnummer int PRIMARY KEY,
	Bynavn varchar(75)
);

CREATE TABLE Adresse (
	AdresseID int IDENTITY(1,1) PRIMARY KEY,
	Postnummer int FOREIGN KEY REFERENCES Postnummer(Postnummer),
	VejNavn varchar(75), 
	Vejnummer varchar(75)
);

CREATE TABLE Butikker (
	ButikID int IDENTITY(1,1) PRIMARY KEY,
	Navn varchar(30),
	AdresseID int FOREIGN KEY REFERENCES Adresse(AdresseID),
);

CREATE TABLE Kunder (
	KundeID int IDENTITY(1,1) PRIMARY KEY,
	Fornavn varchar(45),
	Efternavn varchar(45),
	Mobil int,
	Email varchar(45),
	AdresseID FOREIGN KEY REFERENCES Adresse(AdresseID),
);

CREATE TABLE MyOrdre (
 OrderID int IDENTITY(1,1) PRIMARY KEY,
 KundeID int FOREIGN KEY REFERENCES Kunder(KundeID),
 ButikID int FOREIGN KEY REFERENCES Butikker(ButikID),
 OpretDate DATETIME DEFAULT GETDATE()
);


CREATE TABLE Afdelinger (
	AfdelingerID int IDENTITY(1,1) PRIMARY KEY,
	Navn varchar(46),
);

CREATE TABLE Medarbejdere (
	Medarbejdere int IDENTITY(1,1) PRIMARY KEY,
	Fornavn varchar(45),
	Efternavn varchar(45),
	Mobil int,
	Email varchar(45),
	Status varchar(30),
	Pay int,
	AdresseID int FOREIGN KEY REFERENCES Adresse(AdresseID),
	AfdelingerID int FOREIGN KEY REFERENCES Afdelinger(AfdelingerID),
);



CREATE TABLE ProduktOrder (
	ProduktOrderID int IDENTITY(1,1) PRIMARY KEY,
	OrderID int FOREIGN KEY REFERENCES MyOrdre(OrderID),
	ProduktID int FOREIGN KEY REFERENCES Produkt(ProduktID),
	Antal int,
	Príse int
);


CREATE TABLE Lager (
	LagerID int IDENTITY(1,1) PRIMARY KEY,
	#ProduktID int FOREIGN KEY REFERENCES 
	Antal int,
);
CREATE TABLE Produkt (
	ProduktID int IDENTITY(1,1) PRIMARY KEY,
	ProduktNavn varchar(75),
	Prise int,
);
CREATE TABLE Levering (
	LeveringID int IDENTITY(1,1) PRIMARY KEY,
	OrderID int FOREIGN KEY REFERENCES MyOrdre(OrderID),
	AdresseID int FOREIGN KEY REFERENCES Adresse(AdresseID),
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