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

        public ISet<CustomerWishList> CustomerWishList { get; set; }

        public ISet<ItemLikes> ItemLikes { get; set; }
        public ISet<Transaction> Transactions { get; set; }
    }
}
