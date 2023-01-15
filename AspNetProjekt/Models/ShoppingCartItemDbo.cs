namespace AspNetProjekt.Models
{
    public class ShoppingCartItemDbo
    {
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string? ItemImageName { get; set; }
        public Guid CustomerShoppingCartItemId { get; set; }
    }
}
