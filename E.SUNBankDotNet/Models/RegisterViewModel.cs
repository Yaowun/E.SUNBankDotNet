using System.ComponentModel.DataAnnotations;

namespace E.SUNBankDotNet.Models;

public class RegisterViewModel
{
    [Required]
    [StringLength(20)]
    public string UserID { get; set; }
    [Required]
    [StringLength(50)]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}