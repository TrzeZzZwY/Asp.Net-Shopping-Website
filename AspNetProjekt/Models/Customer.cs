using Microsoft.AspNetCore.Identity;

namespace AspNetProjekt.Models
{
    public class Customer
    {
        public Guid CustomerId;
        public string? IdentityUserId;
        public MyUser? IdentityUser;

        public Guid CustomerShoppingCartsId;
        public CustomerShoppingCart? CustomerShoppingCart;

        public Guid CustomerWishListId;
        public CustomerWishList? CustomerWishList;

        public Guid ItemLikesId;
        public ItemLikes? ItemLikes;

        public Guid TransactionId;
        public Transaction? Transaction;
    }
}
