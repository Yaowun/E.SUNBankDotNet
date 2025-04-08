CREATE PROCEDURE [dbo].[sp_DeleteLikeProduct]
    @SN INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
		
		DECLARE @ProductNo INT;

        SELECT @ProductNo = ProductNo
        FROM [LikeList]
        WHERE SN = @SN;
        
        DELETE FROM [LikeList]
        WHERE SN = @SN;
        
        DELETE FROM [Product]
        WHERE No = @ProductNo;
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
