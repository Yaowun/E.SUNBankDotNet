using E.SUNBankDotNet.Models;

namespace E.SUNBankDotNet.Entities
{
    public class Finance
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal FeeRate { get; set; }
        public int SN { get; set; }
        public int OrderQuantity { get; set; }
        public string Account { get; set; }
        public decimal TotalFee { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    
        public static LikeListViewModel ToLikeListViewModel(Finance finance)
        {
            return new LikeListViewModel
            {
                UserID = finance.UserID,
                ProductNo = finance.ProductNo,
                ProductName = finance.ProductName,
                Price = finance.Price,
                FeeRate = finance.FeeRate,
                SN = finance.SN,
                OrderQuantity = finance.OrderQuantity,
                Account = finance.Account,
                TotalAmount = finance.TotalAmount,
                TotalFee = finance.TotalFee,
                Email = finance.Email,
            };
        }
        public static LikeProductViewModel ToLikeProductViewModel(Finance finance)
        {
            return new LikeProductViewModel
            {
                ProductName = finance.ProductName,
                Price = finance.Price,
                FeeRate = finance.FeeRate,
                SN = finance.SN,
                OrderQuantity = finance.OrderQuantity,
                Account = finance.Account,
            };
        }
    }
}
