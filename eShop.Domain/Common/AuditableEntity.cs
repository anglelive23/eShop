namespace eShop.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
