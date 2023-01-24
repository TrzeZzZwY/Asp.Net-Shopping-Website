using AspNetProjekt.Models;
using AspNetProjekt.Services;
using AspNetProjekt.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetProjekt.Controllers
{
    public class CartController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly UserManager<MyUser> _userManager;
        private readonly ITransactionService _transactionService;

        public CartController(IItemService itemService, IShoppingCartService shoppingCartService,
            UserManager<MyUser> userManager, ITransactionService transactionService)
        {
            _itemService = itemService;
            _shoppingCartService = shoppingCartService;
            _userManager = userManager;
            _transactionService = transactionService;
        }

        [HttpPost]
        public void AddToShoppingCart([FromBody] string id)
        {
            Item item = _itemService.FindBy(Guid.Parse(id));
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            if (_shoppingCartService.Add(item, userId))
                TempData["AddedToCart"] = "Success";
            else
                TempData["AddedToCart"] = "Fail";
        }
        [HttpPost]
        public void RemoveFromShoppingCart([FromBody] string id)
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            if (_shoppingCartService.Delete(Guid.Parse(id), userId))
                TempData["RemovedFromCart"] = "Success";
            else
                TempData["RemovedFromCart"] = "Fail";
        }

        public IActionResult MyCart()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            var shoppingCartItemDbo = _shoppingCartService.FindAllItemsInCartDboBy(userId);
            return View("MyCart", shoppingCartItemDbo);
        }
        [HttpPost]
        public void BuyAllInCart()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            CustomerShoppingCart shoppingCart = _shoppingCartService.FindBy(userId);
            if (_transactionService.Save(shoppingCart) is not null)
                _shoppingCartService.DeleteAll(userId);
        }
    }
}
