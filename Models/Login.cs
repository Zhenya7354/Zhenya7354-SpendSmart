using System.ComponentModel.DataAnnotations;

namespace SpendSmart_Second_Web_application_.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Incorrect Name. Please try again")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Incorrect Password. Please try again")]
        public string Password { get; set; }
    }
}
