using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace HandicraftStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [Column(TypeName ="SmallMoney")]
        [Required]
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile CraftImage { get; set; }
        public virtual List<Orders> ProductOrder { get; set; }
        [NotMapped]
        public object GetById { get; internal set; }
        [NotMapped]
        public string imagepath { get; set; }
        [NotMapped]
        public int Quantity { get; set; }
    }
}
