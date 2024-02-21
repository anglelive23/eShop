namespace eShop.Application.Models.Dtos
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CreateUnitOfMeasureDto? UOM { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }
    }
}
