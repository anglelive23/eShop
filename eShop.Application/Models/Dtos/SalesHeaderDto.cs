namespace eShop.Application.Models.Dtos
{
    public class SalesHeaderDto
    {
        public int Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public Status Status { get; set; }
        public ApplicationUser? Customer { get; set; }
        public string CustomerId { get; set; }
        public string? DiscountPromoCode { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public List<SalesLineDto>? SalesLines { get; set; }
    }
}
