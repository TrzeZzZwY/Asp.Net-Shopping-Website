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

                if (item.CustomerShoppingCart_Item is not null)
                    foreach (var CustomerShoppingCart in item.CustomerShoppingCart_Item)
                        _context.Attach(CustomerShoppingCart);

                if (item.Transaction_Items is not null)
                    foreach (var Transaction_Item in item.Transaction_Items)
                        _context.Attach(Transaction_Item);

                if (item.ItemLikes is not null)
                    foreach (var ItemLike in item.ItemLikes)
                        _context.Attach(ItemLike);

                if (item.CustomerWishList is not null)
                    foreach (var CustomerWishList in item.CustomerWishList)
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
                //if (item.Categories is not null)
                //    foreach (var itemCategory in item.Categories)
                //        _context.Attach(itemCategory);
                //find.Categories = item.Categories;
                find.CustomerShoppingCart_Item = item.CustomerShoppingCart_Item;
                find.Transaction_Items = item.Transaction_Items;
                find.ItemLikes = item.ItemLikes;
                find.CustomerWishList = item.CustomerWishList;
                find.ItemImageName = item.ItemImageName;
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
            throw new NotImplementedException();
        }

        public int? GetWishes(Guid? id)
        {
            throw new NotImplementedException();
        }

        public bool Like(Item item)
        {
            throw new NotImplementedException();
        }

        public bool Wish(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
