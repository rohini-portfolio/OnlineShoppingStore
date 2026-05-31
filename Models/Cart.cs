using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public string UserId { get; set; } // Foreign key to ApplicationUser
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        [Required]
        public int CartId { get; set; } // Foreign key to Cart
        [Required]
        public int ProductId { get; set; } // Foreign key to Product
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Store price at the time of adding to cart
        public virtual Cart Cart { get; set; }
    }
}
