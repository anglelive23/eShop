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
        public string CustomerId { get; set; } // --> needed
        public string? DiscountPromoCode { get; set; } // --> needed but optional
        public decimal? DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public List<SalesLine>? SalesLines { get; set; } // --> needed
    }
}
