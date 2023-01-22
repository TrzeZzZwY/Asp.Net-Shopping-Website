using AspNetProjekt.Areas.Identity.Data;
using AspNetProjekt.Models;
using AspNetProjekt.Services.interfaces;

namespace AspNetProjekt.Services
{
    public class TransactionService : ITransactionService
    {

        private IdentityContext _context;
        private IClockProvider _clockProvider;

        public TransactionService(IdentityContext context, IClockProvider clockProvider)
        {
            _context = context;
            _clockProvider = clockProvider;
        }

        public bool Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Transaction> FindAll()
        {
            return _context.Transactions.ToList();
        }

        public ICollection<Transaction> FindAllFor(Guid UserId)
        {
            List<Transaction> transactions = _context.Transactions.Where(e => e.CustomerId == UserId).ToList();
            foreach (var transaction in transactions)
            {
                _context.Entry(transaction).Collection(e => e.transaction_Items).Load();
            }
            return transactions;
        }

        public Transaction? FindBy(Guid? id)
        {
            Transaction? transaction = _context.Transactions.Find(id);
            _context.Entry(transaction).Collection(e => e.transaction_Items).Load();
            foreach (var item in transaction.transaction_Items)
            {
                _context.Entry(item).Reference(e => e.Item).Load();
            }
            return transaction;
        }

        public ICollection<Transaction> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Guid? Save(CustomerShoppingCart shoppingCart)
        {
            if (shoppingCart.CustomerShoppingCart_Items.Count == 0)
                return null;
            Transaction transaction = new Transaction()
            {
                CustomerId = shoppingCart.CustomerId,
                transaction_Items = new List<Transaction_Item>(),
                TransactionDate = _clockProvider.Now()
            };
            var entity = _context.Transactions.Add(transaction);
            foreach (var shoppingCart_Item in shoppingCart.CustomerShoppingCart_Items)
            {
                _context.Entry(shoppingCart_Item).Reference(e => e.Item).Load();
                if(shoppingCart_Item.Item.ItemAvalibility == 0)
                {
                    _context.Transactions.Remove(transaction);
                    return null;
                }
                shoppingCart_Item.Item.ItemAvalibility--;
                Transaction_Item transaction_Item = new Transaction_Item()
                {
                    Transaction = transaction,
                    Item = shoppingCart_Item.Item,
                    ItemPrice = shoppingCart_Item.Item.ItemPrice * (1 - (shoppingCart_Item.Item.ItemDiscount / 100)),
                };
                _context.Transaction_Items.Add(transaction_Item);
                transaction.transaction_Items.Add(transaction_Item);
            }
            _context.SaveChanges();
            shoppingCart.CustomerShoppingCart_Items = new List<CustomerShoppingCart_Item>();
            return entity.Entity.TransactionId;
        }

        public bool Update(CustomerShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
