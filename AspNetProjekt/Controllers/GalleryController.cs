using AspNetProjekt.Models;
using AspNetProjekt.Services;
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

        public GalleryController(IItemService itemService, ICategoryService categoryService,
            IShoppingCartService shoppingCartService, IWebHostEnvironment hostEnvironment, 
            UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _shoppingCartService = shoppingCartService;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View("Index", _itemService.FindAll());
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
