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
            try
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
            catch (Exception)
            {

                return false;
            }


        }

        public bool Delete(Guid? id, Guid UserId)
        {
            try
            {
                if (id is null)
                    return false;

                CustomerShoppingCart shoppingCart = _context.CustomersShoppingCarts.Find(UserId);
                if (shoppingCart is null)
                    return false;

                var item = FindItemInCartBy(id);
                if (item is null)
                    return false;

                _context.customerShoppingCart_Items.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<CustomerShoppingCart> FindAllBy()
        {
            return _context.CustomersShoppingCarts.ToList();
        }

        public ICollection<CustomerShoppingCart_Item> FindAllItemsInCartBy(Guid? UserId)
        {
            var cart = FindBy(UserId);
            if (cart is null)
                return new List<CustomerShoppingCart_Item>();
            var list = _context.customerShoppingCart_Items.ToList();
            if (list is null)
                return new List<CustomerShoppingCart_Item>();
            return list;
        }

        public CustomerShoppingCart? FindBy(Guid? id)
        {
            return _context.CustomersShoppingCarts.Find(id);
        }
        public CustomerShoppingCart_Item? FindItemInCartBy(Guid? id)
        {
            return _context.customerShoppingCart_Items.Find(id);
        }

        public bool DeleteAll(Guid UserId)
        {
            try
            {
                var items = FindAllItemsInCartBy(UserId);
                if (items is null || items.Count == 0)
                    return false;
                foreach (var item in items)
                    if (Delete(item.CustomerShoppingCart_ItemId, UserId) == false)
                        return false;
                return true;
            }
            catch
            {
                return false;
            }
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
            try
            {
                var old = FindBy(shoppingCart.CustomerId);
                if (old is null)
                    return false;
                old.CustomerShoppingCart_Items = shoppingCart.CustomerShoppingCart_Items;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
