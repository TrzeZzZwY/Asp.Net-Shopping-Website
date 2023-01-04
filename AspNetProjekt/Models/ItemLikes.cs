using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class ItemLikes
    {
        [Key]
        public Guid CustomerId;
        public Customer? Customer;
        [Key]
        public Guid ItemId;
        public Item? Item;
    }
}
