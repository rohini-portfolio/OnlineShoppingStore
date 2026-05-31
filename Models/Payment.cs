using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int OrderId { get; set; } // Foreign key to Order
        [Required]
        public string UserId { get; set; } // Foreign key to ApplicationUser
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string PaymentMethod { get; set; } // e.g., "Credit Card", "PayPal"
        [Required]
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; } // ID from payment gateway
        public string Description { get; set; }
    }
}
