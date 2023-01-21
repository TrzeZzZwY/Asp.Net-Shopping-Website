using AspNetProjekt.Models;

namespace AspNetProjekt.Services
{
    public interface IShoppingCartService
    {
        public bool Save(CustomerShoppingCart shoppingCart);

        public bool Delete(Guid itemId, Guid UserId);

        public bool DeleteAll(Guid UserId);
        public bool Update(CustomerShoppingCart shoppingCart);
        
        public CustomerShoppingCart? FindBy(Guid? id);
        public ICollection<CustomerShoppingCart> FindAllBy();
        public CustomerShoppingCart_Item? FindItemInCartBy(Guid? id);

        public ICollection<CustomerShoppingCart_Item> FindAllItemsInCartBy(Guid? UserId);
        public ICollection<ShoppingCartItemDbo> FillAllItemsInCartDboBy(Guid? UserId);

        public bool Add(Item Item, Guid UserId);
    }
}
