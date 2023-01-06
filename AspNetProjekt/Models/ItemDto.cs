using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetProjekt.Models
{
    public class ItemDto
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemDiscout { get; set; }
        public int ItemAvalibility { get; set; }
        public long[] members { get; set; }
        public List<string>? Categories { get; set; }
        public Item ConvertTo() => new Item()
        {
            ItemId = Guid.NewGuid(),
            ItemName = this.ItemName,
            ItemPrice = this.ItemPrice,
            ItemDiscout = this.ItemDiscout,
            ItemAvalibility = this.ItemAvalibility,
            Categories = null
        };
        public List<SelectListItem> categoriesList { get; set; }


    }
}
