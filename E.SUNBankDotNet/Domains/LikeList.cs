namespace E.SUNBankDotNet.Domains
{
    public class LikeList
    {
        public int No { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal FeeRate { get; set; }
        public int OrderQuantity { get; set; }
        public string Account { get; set; }
        public decimal TotalFee { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
