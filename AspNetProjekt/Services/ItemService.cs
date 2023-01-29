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

            if (_context.Transaction_Items.Any(e => e.ItemId == id) ||
                _context.customerShoppingCart_Items.Any(e => e.ItemId == id) ||
                _context.Customers.Any(e => e.ItemLikes.Any(e => e.ItemId == id)) ||
                _context.Customers.Any(e => e.CustomerWishList.Any(e => e.ItemId == id)))
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
                if (find.ItemAvalibility == 0 && item.ItemAvalibility != 0)
                    SendMessages(item);
                find.ItemAvalibility = item.ItemAvalibility;
                _context.Entry(find).Collection(e => e.Categories).Load();
                find.Categories = new HashSet<Category>();
                foreach (var category in item.Categories)
                    find.Categories.Add(_context.Categories.Find(category.CategoryId));

                //find.CustomerShoppingCart_Item = item.CustomerShoppingCart_Item;
                //find.Transaction_Items = item.Transaction_Items;
                //find.ItemLikes = item.ItemLikes;
                //find.CustomerWishList = item.CustomerWishList;
                find.ItemImageName = item.ItemImageName;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SendMessages(Item item)
        {
            var customersWishItems = _context.customerWishItems.Where(e => e.Item == item).ToList();
            foreach (var customersWishItem in customersWishItems)
            {
                var cust = _context.customerWishItems.Find(customersWishItem.CustomerWishItemId);

                var a = _context.customerWishItemMessages.Add(
                    new CustomerWishItemMessage()
                    {
                        CustomerWishItem = cust,
                        Viewed = false,
                        message = $"Jeden z przedmiotów w twojej liście życzeń jest spowrotem dostępny ( {item.ItemName} )"
                    }
                    );
                _context.SaveChanges();
            }
        }
        public void VisitMessage(Guid id)
        {
            var customerWishItemMessage = _context.customerWishItemMessages.Find(id);
            if (customerWishItemMessage is not null)
            {
                customerWishItemMessage.Viewed = true;
                _context.SaveChanges();
            }
        }
        public ICollection<Item> FindAll()
        {
            List<Item> items = _context.Items.ToList();
            foreach (var item in items)
            {
                _context.Entry(item).Collection(e => e.ItemLikes).Load();
                _context.Entry(item).Collection(e => e.CustomerWishList).Load();
                _context.Entry(item).Collection(e => e.Categories).Load();
            }
            return items;
        }

        public Item? FindBy(Guid? id)
        {
            if (id is null)
                return null;
            Item? item = _context.Items.Find(id);
            if (item is null)
                return null;
            _context.Entry(item).Collection(e => e.ItemLikes).Load();
            _context.Entry(item).Collection(e => e.CustomerWishList).Load();
            _context.Entry(item).Collection(e => e.Categories).Load();
            return item;
        }

        public ICollection<Item> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetLikes(Guid id)
        {
            Customer? customer = _context.Customers.Find(id);
            if (customer == null)
                return new List<Item>();
            _context.Entry(customer).Collection(e => e.ItemLikes).Load();
            return customer.ItemLikes;
        }

        public ICollection<Item> GetWishes(Guid id)
        {
            Customer? customer = _context.Customers.Find(id);
            if (customer == null)
                return new List<Item>();
            _context.Entry(customer).Collection(e => e.CustomerWishList).Load();
            foreach (var item in customer.CustomerWishList)
            {
                _context.Entry(item).Reference(e => e.Item).Load();
            }
            return customer.CustomerWishList.Select(e => e.Item).ToList();
        }
        public ICollection<CustomerWishItemMessage> GetMessages(Guid id)
        {
            Customer? customer = _context.Customers.Find(id);
            List<CustomerWishItemMessage> output = new List<CustomerWishItemMessage>();
            if (customer == null)
                return output;
            List<CustomerWishItem> customerWishItems = _context.customerWishItems.Where(e => e.Customer == customer).ToList();
            foreach (var item in customerWishItems)
            {
                _context.Entry(item).Collection(e => e.customerWishItemMessages).Load();
                if (item.customerWishItemMessages is not null)
                    foreach (var message in item.customerWishItemMessages)
                    {
                        output.Add(message);
                    }
            }
            return output;
        }

        public bool Like(Guid itemId, Guid userId)
        {
            Item? item = FindBy(itemId);
            Customer? customer = _context.Customers.Find(userId);
            if (item == null || customer == null)
                return false;
            _context.Entry(item).Collection(e => e.ItemLikes).Load();
            if (item.ItemLikes.Contains(customer))
                item.ItemLikes.Remove(customer);
            else
                item.ItemLikes.Add(customer);
            _context.SaveChanges();
            return true;
        }

        public bool Wish(Guid itemId, Guid userId)
        {
            Item? item = FindBy(itemId);
            Customer? customer = _context.Customers.Find(userId);
            if (item == null || customer == null)
                return false;
            _context.Entry(item).Collection(e => e.CustomerWishList).Load();
            if (item.CustomerWishList.Any(e => e.Customer == customer))
                item.CustomerWishList.Remove(item.CustomerWishList.Where(e => e.Customer == customer).First());
            else
                item.CustomerWishList.Add(new CustomerWishItem()
                {
                    Item = item,
                    Customer = customer,
                    customerWishItemMessages = new HashSet<CustomerWishItemMessage>()
                });
            _context.SaveChanges();
            return true;
        }
    }
}
