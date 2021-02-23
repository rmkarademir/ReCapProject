CREATE TABLE Cars(
	CarId int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelName nvarchar(25),
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
)

CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)

CREATE TABLE Users(
	UserId int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Email nvarchar(55),
	Password nvarchar(35),
)


CREATE TABLE Customers(
	CustomerId int PRIMARY KEY IDENTITY(1,1),
	UserId int,
	CustomerName nvarchar(25),
	FOREIGN KEY (UserId) REFERENCES Users(UserId),
)

CREATE TABLE Rentals(
	RentalId int PRIMARY KEY IDENTITY(1,1),
	CarId int,
	CustomerID int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY (CarId) REFERENCES Cars(CarId),
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),

)




INSERT INTO Cars(BrandId,ColorId,ModelName,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','Auris','2012','100','Manuel Benzin'),
	('1','3','X5','2015','150','Otomatik Dizel'),
	('2','1','Corolla','2017','200','Otomatik Hybrid'),
	('3','3','Clio','2014','125','Manuel Dizel');

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Mavi');


INSERT INTO Brands(BrandName)
VALUES
	('Tesla'),
	('BMW'),
	('Renault');