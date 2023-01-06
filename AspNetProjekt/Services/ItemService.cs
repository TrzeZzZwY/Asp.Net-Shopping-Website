using AspNetProjekt.Areas.Identity.Data;
using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public class ItemService : IItemService
    {
        private IdentityContext _context;

        public ItemService(IdentityContext identityContext)
        {
            _context = identityContext;
        }
        public Guid? Save(Item item)
        {
            try
            {
                if (item.Categories is not null)
                    foreach (var Category in item.Categories)
                        _context.Attach(Category);

                if (item.CustomerShoppingCarts is not null)
                    foreach (var CustomerShoppingCart in item.CustomerShoppingCarts)
                        _context.Attach(CustomerShoppingCart);

                if (item.Transaction_Items is not null)
                    foreach (var Transaction_Item in item.Transaction_Items)
                        _context.Attach(Transaction_Item);

                if (item.ItemLikes is not null)
                    foreach (var ItemLike in item.ItemLikes)
                        _context.Attach(ItemLike);

                if (item.CustomerWishLists is not null)
                    foreach (var CustomerWishList in item.CustomerWishLists)
                        _context.Attach(CustomerWishList);

                var entity = _context.Items.Add(item);
                _context.SaveChanges();
                return entity.Entity.ItemId;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(Guid? id)
        {
            if (id is null)
                return false;

            var find = _context.Items.Find(id);
            if (find is null)
                return false;

            _context.Items.Remove(find);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Item item)
        {
            try
            {
                var find = _context.Items.Find(item.ItemId);
                if (find is null)
                    return false;
                find.ItemName = item.ItemName;
                find.ItemPrice = item.ItemPrice;
                find.ItemDiscount = item.ItemDiscount;
                find.ItemAvalibility = item.ItemAvalibility;
                find.Categories = item.Categories;
                find.CustomerShoppingCarts = item.CustomerShoppingCarts;
                find.Transaction_Items = item.Transaction_Items;
                find.ItemLikes = item.ItemLikes;
                find.CustomerWishLists = item.CustomerWishLists;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<Item> FindAll()
        {
            return _context.Items.ToList();
        }

        public Item? FindBy(Guid? id)
        {
            return id is null ? null : _context.Items.Find(id);
        }

        public ICollection<Item> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public int? GetLikes(Guid? id)
        {
            return (from i in _context.Items
                    join il in _context.ItemsLikes on i.ItemId equals il.ItemId
                    select il).Count();
        }

        public int? GetWishes(Guid? id)
        {
            return (from i in _context.Items
                    join wl in _context.UsersWishLists on i.ItemId equals wl.ItemId
                    select wl).Count();
        }
    }
}
