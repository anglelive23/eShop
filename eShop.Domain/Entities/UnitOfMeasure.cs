using eShop.Domain.Common;

namespace eShop.Domain.Entities
{
    public class UnitOfMeasure : AuditableEntity
    {
        public int Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
    }
}
