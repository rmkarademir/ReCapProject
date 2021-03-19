CREATE TABLE [dbo].[Brands] (
    [BrandId]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[CarImages] (
    [ImageId]   INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([ImageId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);

CREATE TABLE [dbo].[Cars] (
    [CarId]       INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]     INT           NULL,
    [ColorId]     INT           NULL,
    [ModelName]   NVARCHAR (25) NULL,
    [ModelYear]   NVARCHAR (25) NULL,
    [DailyPrice]  DECIMAL (18)  NULL,
    [Description] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);

CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NULL,
    [CompanyName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

CREATE TABLE [dbo].[OperationClaims] (
    [OperationClaimId] INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([OperationClaimId] ASC)
);

CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [UserOperationClaimId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]               INT NOT NULL,
    [OperationClaimId]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserOperationClaimId] ASC)
);

CREATE TABLE [dbo].[Users] (
    [UserId]       INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (25)   NOT NULL,
    [LastName]     NVARCHAR (25)   NOT NULL,
    [Email]        NVARCHAR (25)   NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);



INSERT INTO Cars(BrandId,ColorId,ModelName,ModelYear,DailyPrice,Description)
VALUES
	('1','2','Auris','2012','100','Manuel Benzin'),
	('1','3','Megane','2015','150','Otomatik Dizel'),
	('2','1','M3','2017','200','Otomatik Dizel'),
	('3','2','Corolla','2014','125','Otomatik Dizel');

INSERT INTO Colors(ColorName)
VALUES
	('Beyaz'),
	('Siyah'),
	('Mavi');


INSERT INTO Brands(BrandName)
VALUES
	('BMW'),
	('Toyota'),
	('Renault');