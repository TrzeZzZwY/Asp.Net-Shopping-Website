using AspNetProjekt.Areas.Identity.Data;
using AspNetProjekt.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetProjekt.Services
{
    public class CategoryService : ICategoryService
    {
        private IdentityContext _context;
        public CategoryService(IdentityContext identityContext)
        {
            _context = identityContext;
        }

        public bool Delete(Guid? id)
        {
            if (id is null)
                return false;

            var find = _context.Categories.Find(id);
            if (find is null)
                return false;

            _context.Categories.Remove(find);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Category> FindAll()
        {
            return _context.Categories.ToList();
        }

        public ICollection<SelectListItem> FindAllAsSelectList()
        {
            var categories = FindAll().ToList();
            var categoriesList = new List<SelectListItem>();

            foreach (var category in categories)
                categoriesList.Add(new SelectListItem(category.CategoryName, category.CategoryId.ToString()));

            return categoriesList;
        }

        public Category? FindBy(Guid? id)
        {
            return id is null ? null : _context.Categories.Find(id);
        }

        public ICollection<Category> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Guid? Save(Category category)
        {
            try
            {
                var entity = _context.Categories.Add(category);
                _context.SaveChanges();
                return entity.Entity.CategoryId;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Category category)
        {
            try
            {
                var find = _context.Categories.Find(category.CategoryId);
                if (find is null)
                    return false;
                find.CategoryName = category.CategoryName;
                find.items = category.items;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
