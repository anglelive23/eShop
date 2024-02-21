namespace eShop.Application.Models.Dtos
{
    public class UnitOfMeasureDto
    {
        public int Id { get; set; }
        public string UOM { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
