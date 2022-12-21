using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class UserShoppingCart
    {
        [Key]
        public Guid UserId;
        public List<Item>? Items;
    }
}
