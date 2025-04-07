CREATE PROCEDURE [dbo].[sp_DeleteLikeProduct]
    @UserID NVARCHAR(20),
    @ProductName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ProductNo INT;

        SELECT @ProductNo = [No]
        FROM [Product]
        WHERE ProductName = @ProductName;

        IF @ProductNo IS NOT NULL
        BEGIN
            DELETE FROM [LikeList]
            WHERE UserID = @UserID AND ProductNo = @ProductNo;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
