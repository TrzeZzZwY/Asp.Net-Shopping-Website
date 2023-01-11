using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetProjekt.Models
{
    public class ItemDto
    {
        public ItemDto()
        {

        }
        public ItemDto(Item item)
        {
            ItemId = item.ItemId.ToString();
            ItemAvalibility = item.ItemAvalibility;
            ItemDescription = item.ItemDescription;
            ItemDiscout = item.ItemDiscount;
            ItemName = item.ItemName;
            ItemPrice = item.ItemPrice;
        }
        [HiddenInput]
        public string? ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemDiscout { get; set; }
        public int ItemAvalibility { get; set; }
        public string? ItemDescription { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public List<string>? Categories { get; set; }
        public Item ConvertTo() => new Item()
        {
            ItemId = Guid.NewGuid(),
            ItemName = this.ItemName,
            ItemPrice = this.ItemPrice,
            ItemDiscount = this.ItemDiscout,
            ItemAvalibility = this.ItemAvalibility,
            ItemDescription = this.ItemDescription,
            Categories = AssignCategories(Categories)
        };
        [ValidateNever]
        public List<SelectListItem>? categoriesList { get; set; }

        private ISet<Category> AssignCategories(List<string>? ids)
        {
            HashSet<Category> categories = new HashSet<Category>();
            if (ids is not null)
                foreach (var item in ids)
                    categories.Add(new Category() { CategoryId = Guid.Parse(item) });
            return categories;
        }
    }
}
