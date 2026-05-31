using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Dtos
{
    public class PaymentDto
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // Credit Card, Debit Card, UPI, Cash On Delivery

        public string Description { get; set; }
    }

    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}