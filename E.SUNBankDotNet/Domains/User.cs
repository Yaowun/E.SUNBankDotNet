using System.ComponentModel.DataAnnotations;

namespace E.SUNBankDotNet.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
    }
}
