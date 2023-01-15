using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ISet<Item>? items { get; set; }
    }
}
