
using System.ComponentModel.DataAnnotations;

namespace SpendSmart_Second_Web_application_.Models
{
    public class Register
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
