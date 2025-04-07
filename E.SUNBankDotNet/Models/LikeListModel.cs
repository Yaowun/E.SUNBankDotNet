using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E.SUNBankDotNet.Models
{
    public class LikeList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SN { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public decimal TotalFee { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
    }
}
