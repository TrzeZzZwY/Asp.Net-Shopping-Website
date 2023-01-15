using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerWishList
    {
        [Key]
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [Key]
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
