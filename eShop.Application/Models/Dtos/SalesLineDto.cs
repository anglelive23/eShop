namespace eShop.Application.Models.Dtos
{
    public class SalesLineDto
    {
        public int Id { get; set; }
        public int SalesHeaderId { get; set; }
        public ItemDto? Item { get; set; }
        public int ItemId { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }
    }
}
