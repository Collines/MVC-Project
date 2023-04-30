namespace MVC_Project.DTOs
{
    public class ShoppingCartDTO
    {
        public string? Message { get; set; }
        public double CartTotalPrice { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public double PriceAfterDiscount { get; set; }
        public string? ImageURI { get; set; }
        public int CartCount { get; set; }
        //public int ItemCount { get; set; }
    }
}
