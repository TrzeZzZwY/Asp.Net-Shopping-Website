using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<Transaction_Item>? transaction_Items { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
