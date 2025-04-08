CREATE PROCEDURE [dbo].[sp_InsertUser]
    @UserID NVARCHAR(20),
    @UserName NVARCHAR(50),
    @Email NVARCHAR(100)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [User] WHERE UserID = @UserID)
    BEGIN
        INSERT INTO [User] (UserID, UserName, Email)
        VALUES (@UserID, @UserName, @Email)
    END
END;
