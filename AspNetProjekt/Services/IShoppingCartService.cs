using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public interface IShoppingCartService
    {
        public bool Save(CustomerShoppingCart shoppingCart);

        public bool Delete(Guid? id, Guid UserId);

        public bool DeleteAll(Guid UserId);
        public bool Update(CustomerShoppingCart shoppingCart);

        public CustomerShoppingCart? FindBy(Guid? id);
        public ICollection<CustomerShoppingCart> FindAllBy();
        public CustomerShoppingCart_Item? FindItemInCartBy(Guid? id);

        public ICollection<CustomerShoppingCart_Item> FindAllItemsInCartBy(Guid? UserId);

        public bool AddItemToShoppingCart(Item Item, Guid UserId);
    }
}
