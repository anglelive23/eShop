namespace eShop.Application.Models.Dtos
{
    public class UpdateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UOMId { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }
    }
}
