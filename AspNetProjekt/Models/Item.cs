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
        public List<UserShoppingCart>? userShoppingCarts;
        public List<Transaction_Item>? transaction_Items;
        public List<ItemLikes>? ItemLikes;
        public List<UserWishList>? userWishLists;
    }
}
