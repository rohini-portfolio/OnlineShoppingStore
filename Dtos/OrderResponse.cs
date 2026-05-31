namespace OnlineShoppingStore.Dtos
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }
        public string Message { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}