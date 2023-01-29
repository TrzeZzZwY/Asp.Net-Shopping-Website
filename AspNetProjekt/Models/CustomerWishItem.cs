namespace AspNetProjekt.Models
{
    public class CustomerWishItem
    {

        public Guid CustomerWishItemId { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ISet<CustomerWishItemMessage>? customerWishItemMessages { get; set; }
    }
}
