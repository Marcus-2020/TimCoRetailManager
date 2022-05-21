CREATE TABLE dto.[User] (
    Id NVARCHAR(128) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    EmailAddress NVARCHAR(256) NOT NULL,
    CreatedDate DATETIME2(7) NOT NULL DEFAULT  GETUTCDATE()
);

CREATE TABLE dto.[Sale] (
    Id INT IDENTITY NOT NULL PRIMARY KEY,
    CashierId NVARCHAR(128) NOT NULL,
    SaleDate DATETIME2(7) NOT NULL,
    SubTotal MONEY NOT NULL,
    Tax MONEY NOT NULL,
    Total MONEY NOT NULL
);

CREATE TABLE dto.[SaleDetail] (
    Id INT IDENTITY NOT NULL PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity int NOT NULL,
    PurchasePrice MONEY NOT NULL,
    Tax MONEY NOT NULL DEFAULT 0
);

CREATE TABLE dto.[Product] (
    Id INT IDENTITY NOT NULL PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    RetailPrice MONEY NOT NULL,
    QuantityInStock INTEGER NOT NULL DEFAULT 1,
    CreatedDate DATETIME2(7) NOT NULL DEFAULT  GETUTCDATE(),
    LastModified DATETIME2(7) NOT NULL DEFAULT  GETUTCDATE()
);

CREATE TABLE dto.[Inventory] (
    Id INT IDENTITY NOT NULL PRIMARY KEY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    PurchasePrice MONEY NOT NULL,
    PurchaseDate DATETIME2(7) NOT NULL DEFAULT  GETUTCDATE()
);


INSERT INTO dto.[Product] (Id, ProductName, Description, RetailPrice)
    VALUES 
        (1, 'Product one', 'Product one', 1.00), 
        (2, 'Product two', 'Product two', 1.25), 
        (3, 'Product three', 'Product three', 5.23)