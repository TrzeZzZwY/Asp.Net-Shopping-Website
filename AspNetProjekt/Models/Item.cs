using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Item
    {
        [Key]
        public Guid ItemId;
        public string ItemName;
        public decimal ItemPrice;
        public int ItemDiscout;
        public int ItemAvalibility;
        public ISet<Category>? Categories;
        public List<CustomerShoppingCart>? CustomerShoppingCarts;
        public List<Transaction_Item>? Transaction_Items;
        public List<ItemLikes>? ItemLikes;
        public List<CustomerWishList>? CustomerWishLists;
    }
}
