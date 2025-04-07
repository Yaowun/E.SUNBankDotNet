CREATE PROCEDURE [dbo].[sp_AddLikeProduct]
    @UserID NVARCHAR(20),
    @ProductName NVARCHAR(100),
    @ProductPrice DECIMAL(18,2),
    @FeeRate DECIMAL(5,4),
    @OrderQuantity INT,
    @Account NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ProductNo INT;

        SELECT @ProductNo = [No]
        FROM [Product]
        WHERE ProductName = @ProductName;

        IF @ProductNo IS NULL
        BEGIN
            INSERT INTO [Product] (ProductName, Price, FeeRate)
            VALUES (@ProductName, @ProductPrice, @FeeRate);

            SET @ProductNo = SCOPE_IDENTITY();
        END

        DECLARE @TotalAmount DECIMAL(18,2) = @ProductPrice * @OrderQuantity;
        DECLARE @TotalFee DECIMAL(18,2) = @TotalAmount * @FeeRate;

        INSERT INTO [LikeList] (
            UserID, ProductNo, OrderQuantity, Account, TotalFee, TotalAmount
        )
        VALUES (
            @UserID, @ProductNo, @OrderQuantity, @Account, @TotalFee, @TotalAmount
        );

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
