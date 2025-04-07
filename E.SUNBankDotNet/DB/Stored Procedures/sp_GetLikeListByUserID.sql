CREATE PROCEDURE [dbo].[sp_GetLikeListByUserID]
    @UserID NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        l.UserID,
        u.UserName,
        u.Email,
        l.ProductNo,
        p.ProductName,
        p.Price AS ProductPrice,
        p.FeeRate,
        l.OrderQuantity,
        l.Account,
        l.TotalFee,
        l.TotalAmount,
        l.CreatedAt
    FROM [LikeList] l
        INNER JOIN [Product] p ON l.ProductNo = p.No
        INNER JOIN [User] u ON l.UserID = u.UserID
    WHERE l.UserID = @UserID;
END;
