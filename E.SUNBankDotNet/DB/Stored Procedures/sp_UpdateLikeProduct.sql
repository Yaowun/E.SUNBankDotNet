CREATE PROCEDURE [dbo].[sp_UpdateLikeProduct]
    @UserID NVARCHAR(20),
    @OriginalProductName NVARCHAR(100),
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

        DECLARE @OldProductNo INT;
        SELECT @OldProductNo = [No]
        FROM [Product]
        WHERE ProductName = @OriginalProductName;

        DECLARE @NewProductNo INT;

        SELECT @NewProductNo = [No]
        FROM [Product]
        WHERE ProductName = @NewProductName;

        IF @NewProductNo IS NULL
        BEGIN
            INSERT INTO [Product] (ProductName, Price, FeeRate)
            VALUES (@NewProductName, @NewPrice, @NewFeeRate);

            SET @NewProductNo = SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            UPDATE [Product]
            SET Price = @NewPrice,
                FeeRate = @NewFeeRate
            WHERE No = @NewProductNo;
        END

        DECLARE @NewTotalAmount DECIMAL(18,2) = @NewPrice * @NewOrderQuantity;
        DECLARE @NewTotalFee DECIMAL(18,2) = @NewTotalAmount * @NewFeeRate;

        UPDATE [LikeList]
        SET 
            ProductNo = @NewProductNo,
            OrderQuantity = @NewOrderQuantity,
            Account = @NewAccount,
            TotalAmount = @NewTotalAmount,
            TotalFee = @NewTotalFee
        WHERE UserID = @UserID AND ProductNo = @OldProductNo;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
