using System.ComponentModel.DataAnnotations;

namespace E.SUNBankDotNet.Models;

public class LikeProductViewModel
{
    public int SN { get; set; }
    [Required]
    [StringLength(100)]
    public string ProductName { get; set; }
    [Required]
    [Range(0.0, double.MaxValue)]
    public decimal Price { get; set; }
    [Required]
    [Range(0.0, 1.0)]
    public decimal FeeRate { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int OrderQuantity { get; set; }
    [Required]
    [RegularExpression(@"^\d{10,20}$")]
    public string Account { get; set; }
}