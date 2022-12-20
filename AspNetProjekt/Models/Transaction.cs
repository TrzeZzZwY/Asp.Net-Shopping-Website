using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction
    {
        [Key]
        public Guid UserId;
        public Guid Transaction_Item;
        public DateTime TransactionDate;
    }
}
