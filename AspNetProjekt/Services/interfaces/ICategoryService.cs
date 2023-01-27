using AspNetProjekt.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetProjekt.Services
{
    public interface ICategoryService
    {
        public Guid? Save(Category category);

        public bool Delete(Guid? id);

        public bool Update(Category category);

        public Category? FindBy(Guid? id);

        public ICollection<Category> FindAll();

        public ICollection<Category> FindPage(int page, int size);
        public ICollection<SelectListItem> FindAllAsSelectList();
    }
}
