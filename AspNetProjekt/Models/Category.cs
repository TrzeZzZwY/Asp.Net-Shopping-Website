using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId;
        public string CategoryName;
        public ISet<Item>? items;
    }
}
