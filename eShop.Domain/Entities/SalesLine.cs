namespace eShop.Domain.Entities
{
    public class SalesLine
    {
        public int Id { get; set; }
        public SalesHeader? SalesHeader { get; set; }
        public int SalesHeaderId { get; set; }
        public Item? Item { get; set; }
        public int ItemId { get; set; } // --> needed
        public int QTY { get; set; } // --> needed

        // calculated value
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; } // --> needed
        public int ExchangeRate { get; set; }
        public decimal ForignPrice => Price / ExchangeRate;
    }
}
