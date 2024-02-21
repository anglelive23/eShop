namespace eShop.Application.Models.Dtos
{
    public class SalesLineDto
    {
        public int Id { get; set; }
        public int SalesHeaderId { get; set; }
        public Item? Item { get; set; }
        public int ItemId { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; }
        public int ExchangeRate { get; set; }
        public decimal ForignPrice => Price / ExchangeRate;
    }
}
