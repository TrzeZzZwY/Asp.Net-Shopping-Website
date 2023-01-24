using AspNetProjekt.Models;
using AspNetProjekt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetProjekt.Areas.Identity.Pages.Account.Manage
{
    public class LikeItemModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly UserManager<MyUser> _userManager;

        public List<Item> LikedItems;

        public LikeItemModel(IItemService itemService, UserManager<MyUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        public void OnGet()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            LikedItems = _itemService.GetLikes(userId).ToList();
        }
    }
}
