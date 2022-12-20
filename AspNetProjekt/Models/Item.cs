using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Item
    {
        [Key]
        public Guid ItemId;
        public string ItemName;
        public decimal ItemPrice;
        public int ItemDiscout;
        public int ItemAvalibility;
        public ISet<Category> Categories;
    }
}
