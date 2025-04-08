CREATE PROCEDURE [dbo].[sp_UpdateLikeProduct]
    @SN int,
    @NewProductName NVARCHAR(100),
    @NewPrice DECIMAL(18,2),
    @NewFeeRate DECIMAL(5,4),
    @NewOrderQuantity INT,
    @NewAccount NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
    
		DECLARE @UserID NVARCHAR(20);
        DECLARE @OldAccount NVARCHAR(30);
        DECLARE @ProductNo INT;

        SELECT @UserID = UserID, @OldAccount = Account, @ProductNo = ProductNo
        FROM [LikeList]
        WHERE SN = @SN;
        
        UPDATE [Account]
        SET
            Account = @NewAccount
        WHERE UserID = @UserID and Account = @OldAccount
    
        UPDATE [Product]
        SET
            ProductName = @NewProductName,
            Price = @NewPrice,
            FeeRate = @NewFeeRate
        WHERE No = @ProductNo;
    
        DECLARE @NewTotalAmount DECIMAL(18,2) = @NewPrice * @NewOrderQuantity;
        DECLARE @NewTotalFee DECIMAL(18,2) = @NewTotalAmount * @NewFeeRate;
    
        UPDATE [LikeList]
        SET
            OrderQuantity = @NewOrderQuantity,
            Account = @NewAccount,
            TotalAmount = @NewTotalAmount,
            TotalFee = @NewTotalFee
        WHERE SN = @SN;
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
