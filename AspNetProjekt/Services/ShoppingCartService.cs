using AspNetProjekt.Areas.Identity.Data;
using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IdentityContext _context;

        public ShoppingCartService(IdentityContext identityContext)
        {
            _context = identityContext;
        }
        public bool AddItemToShoppingCart(Item item, Guid UserId)
        {

            if (item is null)
                return false;
            CustomerShoppingCart shoppingCart = _context.CustomersShoppingCarts.Find(UserId);
            if (shoppingCart is null)
            {
                shoppingCart = new CustomerShoppingCart()
                {
                    CustomerId = UserId,
                    CustomerShoppingCart_Items = new List<CustomerShoppingCart_Item>()
                };
                shoppingCart.CustomerShoppingCart_Items.Add(new CustomerShoppingCart_Item() { CustomerShoppingCart = shoppingCart, Item = item });
                Save(shoppingCart);
            }
            else
            {
                _context.Entry(shoppingCart).Collection(e => e.CustomerShoppingCart_Items).Load();
                shoppingCart.CustomerShoppingCart_Items.Add(new CustomerShoppingCart_Item() { CustomerShoppingCart = shoppingCart, Item = item });
                _context.SaveChanges();
            }

            return true;

        }

        public bool Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<CustomerShoppingCart> FindAll()
        {
            return _context.CustomersShoppingCarts.ToList();
        }

        public CustomerShoppingCart? FindBy(Guid? id)
        {
            return _context.CustomersShoppingCarts.Find(id);
        }

        public bool RemoveAllItemsFromShoppingCart(Guid UserId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItemFromShoppingCart(Item item, Guid UserId)
        {
            throw new NotImplementedException();
        }

        public bool Save(CustomerShoppingCart shoppingCart)
        {
            try
            {
                if (shoppingCart.CustomerShoppingCart_Items is not null)
                    foreach (var item in shoppingCart.CustomerShoppingCart_Items)
                        _context.Attach(item);
                _context.CustomersShoppingCarts.Add(shoppingCart);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CustomerShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
