using AspNetProjekt.Models;
using AspNetProjekt.Services;
using AspNetProjekt.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetProjekt.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly IMyAppSettings _myAppSettings;

        public GalleryController(IItemService itemService, ICategoryService categoryService,
            IShoppingCartService shoppingCartService, IWebHostEnvironment hostEnvironment, 
            UserManager<MyUser> userManager, SignInManager<MyUser> signInManager, IMyAppSettings MyAppSettings)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _shoppingCartService = shoppingCartService;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
            _myAppSettings = MyAppSettings;
        }

        public IActionResult Index([FromQuery] string[]? category)
        {
            if (category is not null && category.Length != 0)
            {
                HashSet<string> categories = new HashSet<string>();
                var allCategories = _categoryService.FindAll().Select(e => e.CategoryName).ToList();
                foreach (var item in category)
                    if (allCategories.Contains(item))
                        _myAppSettings.galleryFilteringCategories.Add(item);

            }

            HashSet<Item> items = _itemService.FindAll().ToHashSet();
            HashSet<Item> FileredItems = new HashSet<Item>();
            if (_myAppSettings.galleryFilteringCategories is null || _myAppSettings.galleryFilteringCategories.Count == 0)
                return View("Index", items);

            foreach (var item in items)
                foreach (var filteringCategory in _myAppSettings.galleryFilteringCategories)
                    foreach (var cat in item.Categories)
                        if (cat.CategoryName == filteringCategory)
                            FileredItems.Add(item);

            return View("Index", FileredItems);
        }

        public IActionResult EditItem(Guid? id)
        {
            if (id is null)
                RedirectToAction("index");
            Item? item = _itemService.FindBy(id);
            if (item is null)
                RedirectToAction("index");
            ItemDto itemDto = new ItemDto(item);
            return RedirectToAction("CreateItem", "Shop", itemDto);
        }
        [HttpPost]
        public IActionResult AddFilterCategory([FromBody] string categoryName)
        {
            List<Category> categories = _categoryService.FindAll().ToList();
            if (!categories.Any(e => e.CategoryName == categoryName))
                return Index(_myAppSettings.galleryFilteringCategories.ToArray());
            if (_myAppSettings.galleryFilteringCategories is null)
                _myAppSettings.galleryFilteringCategories = new HashSet<string>();

            if (!_myAppSettings.galleryFilteringCategories.Add(categoryName))
                _myAppSettings.galleryFilteringCategories.Remove(categoryName);

            return RedirectToAction("Index", _myAppSettings.galleryFilteringCategories.ToArray());

        }
    }
}
