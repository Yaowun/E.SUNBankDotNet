CREATE PROCEDURE [dbo].[sp_Authenticate]
    @UserID NVARCHAR(20),
    @Email NVARCHAR(100)
AS
BEGIN
    SELECT UserID, UserName, Email
    FROM [User]
    WHERE UserID = @UserID AND Email = @Email
END;
