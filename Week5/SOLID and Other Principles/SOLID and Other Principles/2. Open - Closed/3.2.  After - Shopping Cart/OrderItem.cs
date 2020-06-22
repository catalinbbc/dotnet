namespace OpenClosedShoppingCartAfter
{
    public abstract class OrderItem
    {
        public string Sku { get; set; }

        public int Quantity { get; set; }
        public abstract decimal TotalAmount();
    }
}