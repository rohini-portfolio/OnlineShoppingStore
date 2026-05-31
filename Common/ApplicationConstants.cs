namespace OnlineShoppingStore.Common
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
    }

    public static class OrderStatus
    {
        public const string Pending = "Pending";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";
    }
    public static class PaymentStatus
    {
        public const string Pending = "Pending";
        public const string Success = "Success";
        public const string Failed = "Failed";
    }
}
