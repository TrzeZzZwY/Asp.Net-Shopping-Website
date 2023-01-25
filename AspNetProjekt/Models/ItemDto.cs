using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
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
            Categories = item.Categories.Select(e => e.CategoryId.ToString()).ToList();
        }
        [HiddenInput]
        public string? ItemId { get; set; }
        [Required(ErrorMessage ="Pole jest wymagane")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż0-9' '\-\s]{1,50}$", ErrorMessage = "Nazwa powinna być nie krótsza niż 0 i nie dłuższa niż 50 i powina składać się z liter lub cyfr")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"^[0-9]+(\,[0-9]{2})?$", ErrorMessage = "Cena powinna być dodatnia w postaci liczby całkowitej lub liczby z 2 liczbami po przecinku")]
        public decimal ItemPrice { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Range(0,100,ErrorMessage = "wartość powinna być z zakresu 0 do 100")]
        public int ItemDiscout { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "ilość powinna być liczbą całkowitą dodatnią")]
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
