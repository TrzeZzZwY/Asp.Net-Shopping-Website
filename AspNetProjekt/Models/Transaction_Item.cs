using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction_Item
    {
        public Guid Transaction_ItemId { get; set; }
        public Guid TransactionId { get; set; }
        public Transaction? Transaction { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
