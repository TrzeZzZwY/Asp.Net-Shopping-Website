using AspNetProjekt.Models;
using AspNetProjekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetProjectxTest
{
    public class ItemServiceTest : IItemService
    {
        private Dictionary<Guid, Item> _context = new Dictionary<Guid, Item>();
        public bool Delete(Guid? id)
        {
            if (id is null)
                return false;
            return _context.Remove((Guid)id);
        }

        public ICollection<Item> FindAll()
        {
            return _context.Values;
        }

        public Item? FindBy(Guid? id)
        {
            if (id is null)
                return null;
            Item? item;
            _context.TryGetValue((Guid)id,out item);
            return item;
        }

        public ICollection<Item> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetLikes(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetWishes(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Like(Guid itemId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Guid? Save(Item item)
        {
            item.ItemId = Guid.NewGuid();
            _context.Add(item.ItemId, item);
            return item.ItemId;
        }

        public bool Update(Item item)
        {
            if (!_context.ContainsKey(item.ItemId))
                return false;
            _context[item.ItemId] = item;
            return true;
        }

        public bool Wish(Guid itemId, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
