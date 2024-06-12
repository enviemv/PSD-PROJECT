CREATE TABLE [dbo].[Table1]
(
	[Id] INT NOT NULL PRIMARY KEY
)
CREATE TABLE Roles (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256) NOT NULL
);
GO

-- Create Users Table
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserName NVARCHAR(256) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    RoleId UNIQUEIDENTIFIER,
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
GO

-- Create SupplementTypes Table
CREATE TABLE SupplementTypes (
    SupplementTypeID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL
);
GO

-- Create Supplements Table
CREATE TABLE Supplements (
    SupplementID INT PRIMARY KEY IDENTITY,
    SupplementName NVARCHAR(MAX) NOT NULL,
    SupplementExpiryDate DATETIME2 NOT NULL,
    SupplementPrice DECIMAL(18, 2) NOT NULL,
    SupplementTypeID INT NOT NULL,
    CONSTRAINT FK_Supplements_SupplementTypes FOREIGN KEY (SupplementTypeID) REFERENCES SupplementTypes(SupplementTypeID) ON DELETE CASCADE
);
GO

-- Create Transactions Table
CREATE TABLE Transactions (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    TransactionDate DATETIME NOT NULL,
    CustomerId UNIQUEIDENTIFIER,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Transactions_Users FOREIGN KEY (CustomerId) REFERENCES Users(Id)
);
GO

-- Create TransactionDetails Table
CREATE TABLE TransactionDetails (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    TransactionId UNIQUEIDENTIFIER,
    SupplementId INT,
    Quantity INT NOT NULL,
    SubTotal DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_TransactionDetails_Transactions FOREIGN KEY (TransactionId) REFERENCES Transactions(Id),
    CONSTRAINT FK_TransactionDetails_Supplements FOREIGN KEY (SupplementId) REFERENCES Supplements(SupplementID)
);
GO

-- Create Cart Table
CREATE TABLE Cart (
    CartID INT PRIMARY KEY IDENTITY,
    UserID UNIQUEIDENTIFIER NOT NULL,
    SupplementID INT NOT NULL,
    Quantity INT NOT NULL,
    CONSTRAINT FK_Cart_Users FOREIGN KEY (UserID) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Cart_Supplements FOREIGN KEY (SupplementID) REFERENCES Supplements(SupplementID) ON DELETE CASCADE
);
GO

-- Unique Constraints and Indexes
ALTER TABLE Users ADD CONSTRAINT UQ_Users_Email UNIQUE (Email);
GO
ALTER TABLE Users ADD CONSTRAINT UQ_Users_UserName UNIQUE (UserName);
GO
CREATE INDEX IX_Transactions_TransactionDate ON Transactions(TransactionDate);
GO
CREATE INDEX IX_TransactionDetails_SupplementId ON TransactionDetails(SupplementId);
GO