using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public interface IItemService
    {
        public Guid? Save(Item item);

        public bool Delete(Guid? id);

        public bool Update(Item item);

        public Item? FindBy(Guid? id);

        public ICollection<Item> FindAll();

        public ICollection<Item> FindPage(int page, int size);
        public bool Like(Guid itemId, Guid userId);
        public bool Wish(Guid itemId, Guid userId);

        public ICollection<Item> GetLikes(Guid id);
        public ICollection<Item> GetWishes(Guid id);
        
    }
}
