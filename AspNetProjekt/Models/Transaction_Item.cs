using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction_Item
    {
        public Guid Transaction_ItemId;
        public Guid TransactionId;
        public Transaction? Transaction;
        public Guid ItemId;
        public Item? Item;
        public decimal ItemPrice;
    }
}
