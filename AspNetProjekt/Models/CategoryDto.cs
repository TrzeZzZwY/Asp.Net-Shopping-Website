namespace AspNetProjekt.Models
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public Category ConvertTo() => new Category()
        {
            CategoryId = Guid.NewGuid(),
            CategoryName = this.CategoryName
        };
    }
}
