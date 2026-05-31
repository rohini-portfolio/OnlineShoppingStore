using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public string Category { get; set; }
        public string ImageUrl { get; set; }

    }
}
