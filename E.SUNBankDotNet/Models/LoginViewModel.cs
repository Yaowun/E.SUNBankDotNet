using System.ComponentModel.DataAnnotations;

namespace E.SUNBankDotNet.Models;

public class LoginViewModel
{
    [Required]
    [StringLength(20)]
    public string UserID { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}