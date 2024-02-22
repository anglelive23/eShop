using eShop.Domain.Common;

namespace eShop.Domain.Entities
{
    public class SalesHeader : AuditableEntity
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
        public string CurrencyCode { get; set; }
        public int ExchangeRate { get; set; }
        public decimal ForignPrice => TotalPrice / ExchangeRate;

        public List<SalesLine>? SalesLines { get; set; }
    }
}
