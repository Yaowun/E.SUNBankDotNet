CREATE PROCEDURE [dbo].[sp_UpdateLikeProduct]
    @ProductNo int,
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
        ProductNo = @ProductNo,
        OrderQuantity = @NewOrderQuantity,
        Account = @NewAccount,
        TotalAmount = @NewTotalAmount,
        TotalFee = @NewTotalFee
    WHERE ProductNo = @ProductNo;
    
    COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
    ROLLBACK TRANSACTION;
            THROW;
    END CATCH
END;
