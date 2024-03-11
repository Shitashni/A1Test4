using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandicraftStore.Models
{
    public class ExchangeRate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        [Range(0.01, 99, ErrorMessage = "Price must be greater than 0.00")]
        [DisplayName("Rate ($)")]
        public decimal Rate { get; set; }
        [NotMapped]
        public decimal CalculatedAmt { get; set; }
    }
}
