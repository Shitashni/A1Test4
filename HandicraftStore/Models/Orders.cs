using HandicraftStore.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandicraftStore.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
 
        public string Email { get; set; }


        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
      //  public virtual List<Product> Products { get; set; }

        public int Quantity { get; set; }
  
        public decimal Amount { get; set; }

      
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string OrderStatus { get; set; }

    }
}
