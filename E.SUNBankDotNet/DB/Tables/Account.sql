CREATE TABLE [dbo].[Account] (
    [AccountID] INT IDENTITY(1,1) PRIMARY KEY,
    [UserID] NVARCHAR(20) NOT NULL,
    [Account] NVARCHAR(30) NOT NULL

    FOREIGN KEY ([UserID]) REFERENCES [dbo].[User]([UserID]),
);