using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId;
        public Guid CustomerId;
        public Customer? Customer;
        public List<Transaction_Item>? transaction_Items;
        public DateTime TransactionDate;
    }
}
