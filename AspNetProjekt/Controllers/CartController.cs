using AspNetProjekt.Models;
using AspNetProjekt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetProjekt.Controllers
{
    public class CartController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;

        public CartController(IItemService itemService, ICategoryService categoryService,
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

        [HttpPost]
        public void AddToShoppingCart([FromBody] string id)
        {
            Item item = _itemService.FindBy(Guid.Parse(id));
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            _shoppingCartService.Add(item, userId);
        }
        [HttpPost]
        public void RemoveFromShoppingCart([FromBody] string id)
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            _shoppingCartService.Delete(Guid.Parse(id), userId);
        }

        public IActionResult MyCart()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            var shoppingCartItemDbo = _shoppingCartService.FillAllItemsInCartDboBy(userId);
            return View("MyCart", shoppingCartItemDbo);
        }
    }
}
