namespace eShop.Application.Models.Dtos
{
    public class CreateSalesHeaderDto
    {
        public string CustomerId { get; set; }
        public string? DiscountPromoCode { get; set; }
        public List<CreateSalesLineDto> SalesLines { get; set; }
    }
}
