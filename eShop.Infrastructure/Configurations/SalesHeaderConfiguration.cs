namespace eShop.Infrastructure.Configurations
{
    public class SalesHeaderConfiguration : IEntityTypeConfiguration<SalesHeader>
    {
        public void Configure(EntityTypeBuilder<SalesHeader> builder)
        {
            builder.Property(u => u.Status)
                .HasDefaultValue(Status.Open);

            builder.Property(u => u.DiscountPromoCode)
                .HasMaxLength(25);

            builder.Property(u => u.DiscountValue)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(u => u.TotalPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
