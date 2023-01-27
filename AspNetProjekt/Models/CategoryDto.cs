using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Nazwa")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻż0-9' '\-\s]{1,50}$", ErrorMessage = "Nazwa powinna być nie krótsza niż 0 i nie dłuższa niż 50 i powina składać się z liter lub cyfr")]
        public string CategoryName { get; set; }
        public Category ConvertTo() => new Category()
        {
            CategoryId = Guid.NewGuid(),
            CategoryName = this.CategoryName
        };
    }
}
