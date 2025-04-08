CREATE PROCEDURE [dbo].[sp_IsUserExists]
    @UserID NVARCHAR(20)
AS
BEGIN
    SELECT COUNT(1)
    FROM [User]
    WHERE UserID = @UserID
END;
