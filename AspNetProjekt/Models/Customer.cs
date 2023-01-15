using Microsoft.AspNetCore.Identity;

namespace AspNetProjekt.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string? IdentityUserId { get; set; }
        public MyUser? IdentityUser { get; set; }

        public Guid CustomerShoppingCartsId { get; set; }
        public CustomerShoppingCart? CustomerShoppingCart { get; set; }

        public Guid CustomerWishListId { get; set; }
        public CustomerWishList? CustomerWishList { get; set; }

        public Guid ItemLikesId { get; set; }
        public ItemLikes? ItemLikes { get; set; }

        public Guid TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
    }
}
