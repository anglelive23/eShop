using eShop.Domain.Common;

namespace eShop.Domain.Entities
{
    public class Item : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UnitOfMeasure? UOM { get; set; }
        public int UOMId { get; set; }
        public int QTY { get; set; }
        public decimal Price { get; set; }
    }
}
