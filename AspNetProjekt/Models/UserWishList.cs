using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class UserWishList
    {
        [Key]
        public Guid UserId;
        [Key]
        public Guid ItemId;
        public Item Item;
    }
}
