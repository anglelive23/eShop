namespace eShop.Infrastructure.Configurations
{
    public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.Property(u => u.UOM)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(u => u.Description)
                .HasMaxLength(25);

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
