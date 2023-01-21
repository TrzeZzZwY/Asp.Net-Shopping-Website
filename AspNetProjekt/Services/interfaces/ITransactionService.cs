using AspNetProjekt.Models;
namespace AspNetProjekt.Services.interfaces
{
    public interface ITransactionService
    {
        public Guid? Save(CustomerShoppingCart shoppingCart);

        public bool Delete(Guid? id);

        public bool Update(CustomerShoppingCart shoppingCart);

        public Transaction? FindBy(Guid? id);

        public ICollection<Transaction> FindAll();
        public ICollection<Transaction> FindAllFor(Guid UserId);

        public ICollection<Transaction> FindPage(int page, int size);

    }
}
