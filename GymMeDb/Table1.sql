-- Create MsUser table
CREATE TABLE MsUser (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(100) NOT NULL,
    UserEmail VARCHAR(100) NOT NULL,
    UserDOB DATE NOT NULL,
    UserGender VARCHAR(10) NOT NULL,
    UserRole VARCHAR(10) NOT NULL
);
GO

-- Create MsSupplementType table
CREATE TABLE MsSupplementType (
    SupplementTypeID INT IDENTITY(1,1) PRIMARY KEY,
    SupplementTypeName VARCHAR(100) NOT NULL
);
GO

-- Create MsSupplement table
CREATE TABLE MsSupplement (
    SupplementID INT IDENTITY(1,1) PRIMARY KEY,
    SupplementName VARCHAR(100) NOT NULL,
    SupplementExpiryDate DATE NOT NULL,
    SupplementPrice DECIMAL(18, 2) NOT NULL,
    SupplementTypeID INT NOT NULL,
    FOREIGN KEY (SupplementTypeID) REFERENCES MsSupplementType(SupplementTypeID)
);
GO

-- Create MsCart table
CREATE TABLE MsCart (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    SupplementID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES MsUser(UserID),
    FOREIGN KEY (SupplementID) REFERENCES MsSupplement(SupplementID)
);
GO

-- Create TransactionHeader table
CREATE TABLE TransactionHeader (
    TransactionID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    TransactionDate DATE NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES MsUser(UserID)
);
GO

-- Create TransactionDetail table
CREATE TABLE TransactionDetail (
    TransactionID INT NOT NULL,
    SupplementID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (TransactionID) REFERENCES TransactionHeader(TransactionID),
    FOREIGN KEY (SupplementID) REFERENCES MsSupplement(SupplementID),
    PRIMARY KEY (TransactionID, SupplementID)
);
GO
