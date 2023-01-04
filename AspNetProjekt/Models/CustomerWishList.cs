using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerWishList
    {
        [Key]
        public Guid CustomerId;
        public Customer? Customer;
        [Key]
        public Guid ItemId;
        public Item? Item;
    }
}
