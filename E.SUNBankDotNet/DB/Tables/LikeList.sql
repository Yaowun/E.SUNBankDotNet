CREATE TABLE [dbo].[LikeList] (
    [SN] INT IDENTITY(1,1) PRIMARY KEY,
    [UserID] NVARCHAR(20) NOT NULL,
    [ProductNo] INT NOT NULL,
    [OrderQuantity] INT NOT NULL,
    [Account] NVARCHAR(30) NOT NULL,
    [TotalFee] DECIMAL(18, 2) NOT NULL,
    [TotalAmount] DECIMAL(18, 2) NOT NULL,
    [CreatedAt] DATETIME DEFAULT GETDATE(),

    FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([UserID]),
    FOREIGN KEY ([ProductNo]) REFERENCES [dbo].[Product]([No])
);
