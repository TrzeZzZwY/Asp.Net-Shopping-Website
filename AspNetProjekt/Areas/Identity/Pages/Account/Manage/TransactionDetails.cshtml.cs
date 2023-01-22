using AspNetProjekt.Models;
using AspNetProjekt.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetProjekt.Areas.Identity.Pages.Account.Manage
{
    public class TransactionDetailsModel : PageModel
    {
        readonly private ITransactionService _transactionService;
        readonly private UserManager<MyUser> _userManager;

        public Transaction transaction;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public TransactionDetailsModel(ITransactionService transactionService, UserManager<MyUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            transaction = _transactionService.FindBy(Guid.Parse(id));

            return Page();
        }
    }
}
