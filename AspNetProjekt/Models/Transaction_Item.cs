using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction_Item
    {
        [Key]
        public Guid TransactionId;
        [Key] 
        public Guid ItemId;
        public decimal ItemPrice;
    }
}
