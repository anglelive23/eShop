using System.Text.Json.Serialization;

namespace eShop.Application.Models.Dtos
{
    public class SalesHeaderDto
    {
        public int Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CloseDate { get; set; }
        [JsonIgnore]
        public Status Status { get; set; }
        public string StatusName => Status.GetName(Status)!;
        public ApplicationUser? Customer { get; set; }
        public string CustomerId { get; set; }
        public string? DiscountPromoCode { get; set; }
        public decimal? DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public string CurrencyCode { get; set; }
        public int ExchangeRate { get; set; }
        public decimal ForignPrice => TotalPrice / ExchangeRate;
        public List<SalesLineDto>? SalesLines { get; set; }
    }
}
