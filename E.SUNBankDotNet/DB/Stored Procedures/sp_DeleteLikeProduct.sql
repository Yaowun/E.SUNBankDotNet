CREATE PROCEDURE [dbo].[sp_DeleteLikeProduct]
    @ProductNo INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
    BEGIN TRANSACTION;
    
    DELETE FROM [LikeList]
    WHERE ProductNo = @ProductNo;
    
    DELETE FROM [Product]
    WHERE No = @ProductNo;
    
    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    ROLLBACK TRANSACTION;
            THROW;
    END CATCH
END;
