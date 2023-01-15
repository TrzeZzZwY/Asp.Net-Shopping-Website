using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerShoppingCart_Item
    {
        public Guid CustomerShoppingCart_ItemId { get; set; }
        public Guid CustomerShoppingCartId { get; set; }
        public CustomerShoppingCart? CustomerShoppingCart { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
