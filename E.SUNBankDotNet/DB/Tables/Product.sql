CREATE TABLE [dbo].[Product] (
    [No] INT IDENTITY(1,1) PRIMARY KEY,
    [ProductName] NVARCHAR(100) NOT NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [FeeRate] DECIMAL(5, 4) NOT NULL
);
