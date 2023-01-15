using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerShoppingCart
    {
        [Key]
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CustomerShoppingCart_Item>? CustomerShoppingCart_Items { get; set; }
    }
}
