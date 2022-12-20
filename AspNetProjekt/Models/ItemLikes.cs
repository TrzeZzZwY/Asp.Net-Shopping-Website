using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class ItemLikes
    {
        [Key]
        public Guid UserId;
        [Key]
        public Guid ItemId;
    }
}
