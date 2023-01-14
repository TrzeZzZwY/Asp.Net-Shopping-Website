using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public interface IShoppingCartService
    {
        public bool Save(CustomerShoppingCart shoppingCart);

        public bool Delete(Guid? id);

        public bool Update(CustomerShoppingCart shoppingCart);

        public CustomerShoppingCart? FindBy(Guid? id);

        public ICollection<CustomerShoppingCart> FindAll();

        public bool AddItemToShoppingCart(Item Item, Guid UserId);
        public bool RemoveItemFromShoppingCart(Item Item, Guid UserId);
        public bool RemoveAllItemsFromShoppingCart(Guid UserId);
    }
}
