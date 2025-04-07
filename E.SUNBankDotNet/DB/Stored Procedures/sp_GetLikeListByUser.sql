CREATE PROCEDURE [dbo].[sp_GetLikeListByUser]
    @UserID NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.ProductName,
        p.Price AS ProductPrice,
        p.FeeRate,
        l.OrderQuantity,
        l.Account,
        l.TotalAmount,
        l.TotalFee,
        u.Email
    FROM [LikeList] l
    INNER JOIN [Product] p ON l.ProductNo = p.No
    INNER JOIN [User] u ON l.UserID = u.UserID
    WHERE l.UserID = @UserID;
END;
