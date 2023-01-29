using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; } 
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemDiscount { get; set; }
        public int ItemAvalibility { get; set; }
        public string? ItemImageName { get; set; }
        public string? ItemDescription { get; set; }
        public ISet<Category>? Categories { get; set; }
        public List<CustomerShoppingCart_Item>? CustomerShoppingCart_Item { get; set; }
        public List<Transaction_Item>? Transaction_Items { get; set; }
        public ISet<Customer>? ItemLikes { get; set; }
        public ISet<CustomerWishItem>? CustomerWishList { get; set; }
    }
}
