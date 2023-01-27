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

        public IActionResult Index([FromQuery] string? category)
        {
            HashSet<Item> items = _itemService.FindAll().ToHashSet();
            HashSet<Item> FileredItems = new HashSet<Item>();
            if (category is null)
                return View("Index", items);

            foreach (var item in items)
                if (item.Categories.Any(e => e.CategoryId.ToString() == category))
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
    }
}
