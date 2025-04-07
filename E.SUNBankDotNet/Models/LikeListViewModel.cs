namespace E.SUNBankDotNet.Models
{
    public class LikeListViewModel
    {
        public string UserID { get; set; }
        public int ProductNo { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal FeeRate { get; set; }
        public int OrderQuantity { get; set; }
        public string Account { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalFee { get; set; }
        public string Email { get; set; }
    }
}
