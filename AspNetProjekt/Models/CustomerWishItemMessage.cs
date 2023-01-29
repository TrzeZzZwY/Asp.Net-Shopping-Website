using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerWishItemMessage
    {
        [Key]
        public Guid CustomerWishItemMessageId { get; set; }
        public Guid CustomerWishItemId { get; set; }
        public CustomerWishItem? CustomerWishItem { get; set; }
        public string? message { get; set; }
        public bool Viewed { get; set; }
    }
}
