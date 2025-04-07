using System.ComponentModel.DataAnnotations;

namespace E.SUNBankDotNet.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Account { get; set; }
    }
}
