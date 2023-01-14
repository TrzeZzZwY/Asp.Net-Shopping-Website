using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerShoppingCart_Item
    {
        public Guid CustomerShoppingCart_ItemId;
        public Guid CustomerShoppingCartId;
        public CustomerShoppingCart? CustomerShoppingCart;
        public Guid ItemId;
        public Item? Item;
    }
}
