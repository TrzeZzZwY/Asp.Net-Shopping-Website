using AspNetProjekt.Models;
using AspNetProjekt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetProjekt.Areas.Identity.Pages.Account.Manage
{
    public class MessagesModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly UserManager<MyUser> _userManager;

        public List<CustomerWishItemMessage> Messages;

        public MessagesModel(IItemService itemService, UserManager<MyUser> userManager)
        {
            _itemService = itemService;
            _userManager = userManager;
        }

        public void OnGet()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            Messages = _itemService.GetMessages(userId).ToList();
        }
        public void OnGetOk(Guid? id)
        {
            if (id is not null)
                _itemService.VisitMessage((Guid)id);
            OnGet();
        }
    }
}
