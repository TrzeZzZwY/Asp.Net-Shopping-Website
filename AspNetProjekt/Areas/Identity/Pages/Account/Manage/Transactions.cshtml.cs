using AspNetProjekt.Models;
using AspNetProjekt.Services.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetProjekt.Areas.Identity.Pages.Account.Manage
{
    public class TransactionsModel : PageModel
    {
        readonly private ITransactionService _transactionService;
        readonly private UserManager<MyUser> _userManager;

        public List<Transaction> transactions;

        public TransactionsModel(ITransactionService transactionService, UserManager<MyUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            Guid userId = Guid.Parse(_userManager.GetUserId(User));
            transactions = _transactionService.FindAllFor(userId).ToList();
            return Page();
        }
    }
}
