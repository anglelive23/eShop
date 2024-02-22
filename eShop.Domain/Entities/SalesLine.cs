namespace eShop.Domain.Entities
{
    public class SalesLine
    {
        public int Id { get; set; }
        public SalesHeader? SalesHeader { get; set; }
        public int SalesHeaderId { get; set; }
        public Item? Item { get; set; }
        public int ItemId { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }
    }
}
