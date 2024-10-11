using System.ComponentModel.DataAnnotations;

namespace SpendSmart_Second_Web_application_.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Value { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
