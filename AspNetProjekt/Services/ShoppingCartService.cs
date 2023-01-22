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
        public bool Add(Item item, Guid UserId)
        {
            try
            {
                if (item is null)
                    return false;
                if (item.ItemAvalibility == 0)
                    return false;

                CustomerShoppingCart shoppingCart = _context.CustomersShoppingCarts.Find(UserId);

                if (shoppingCart is null)
                    shoppingCart = Create(UserId);
                _context.Entry(shoppingCart).Collection(e => e.CustomerShoppingCart_Items).Load();
                shoppingCart.CustomerShoppingCart_Items.Add(new CustomerShoppingCart_Item() { CustomerShoppingCart = shoppingCart, Item = item });
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool Delete(Guid itemId, Guid UserId)
        {
            try
            {
                CustomerShoppingCart shoppingCart = _context.CustomersShoppingCarts.Find(UserId);
                if (shoppingCart is null)
                    return false;

                var item = _context.customerShoppingCart_Items.Find(itemId);
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
            var list = _context.customerShoppingCart_Items.Where(e => e.CustomerShoppingCart == cart).ToList();
            foreach (var item in list)
            {
                _context.Entry(item).Reference(e => e.Item).Load();
            }
            if (list is null)
                return new List<CustomerShoppingCart_Item>();
            return list;
        }

        public CustomerShoppingCart? FindBy(Guid? id)
        {
            if (id is null)
                return null;
            Guid UserId = id ?? Guid.Empty;
            if (UserId == Guid.Empty)
                return null;
            CustomerShoppingCart? shoppingCart = _context.CustomersShoppingCarts.Find(UserId);
            
            if (shoppingCart is null)
                shoppingCart = Create(UserId);
            _context.Entry(shoppingCart).Collection(e => e.CustomerShoppingCart_Items).Load();
            return shoppingCart;
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

        public ICollection<ShoppingCartItemDbo> FindAllItemsInCartDboBy(Guid? UserId)
        {
            List<ShoppingCartItemDbo> shoppingCartItemDbo = new List<ShoppingCartItemDbo>();
            var itemsInCart = FindAllItemsInCartBy(UserId);
            foreach (var itemInCart in itemsInCart)
            {
                shoppingCartItemDbo.Add(new ShoppingCartItemDbo()
                {
                    ItemId = itemInCart.ItemId,
                    ItemImageName = itemInCart.Item.ItemImageName,
                    ItemPrice = itemInCart.Item.ItemPrice,
                    ItemName = itemInCart.Item.ItemName,
                    ItemDiscount = itemInCart.Item.ItemDiscount,
                    CustomerShoppingCartItemId = itemInCart.CustomerShoppingCart_ItemId
                });
            }
            return shoppingCartItemDbo;
        }

        public CustomerShoppingCart Create(Guid UserId)
        {
            CustomerShoppingCart shoppingCart = new CustomerShoppingCart()
            {
                CustomerId = UserId,
                CustomerShoppingCart_Items = new List<CustomerShoppingCart_Item>()
            };
            Save(shoppingCart);
            return shoppingCart;
        }
    }
}
