using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction_Item
    {
        [Key]
        public Guid TransactionId;
        public Transaction? Transaction;
        [Key] 
        public Guid ItemId;
        public Item? Item;
        public decimal ItemPrice;
    }
}
