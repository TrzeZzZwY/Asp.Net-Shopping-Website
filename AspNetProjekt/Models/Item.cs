using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Item
    {
        [Key]
        public Guid ItemId;
        public string ItemName;
        public decimal ItemPrice;
        public int ItemDiscount;
        public int ItemAvalibility;
        public string? ItemImageName;
        public string? ItemDescription;
        public ISet<Category>? Categories;
        public List<CustomerShoppingCart_Item>? CustomerShoppingCart_Item;
        public List<Transaction_Item>? Transaction_Items;
        public List<ItemLikes>? ItemLikes;
        public List<CustomerWishList>? CustomerWishLists;
    }
}
