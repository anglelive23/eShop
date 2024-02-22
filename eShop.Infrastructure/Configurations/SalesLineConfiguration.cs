namespace eShop.Infrastructure.Configurations
{
    public class SalesLineConfiguration : IEntityTypeConfiguration<SalesLine>
    {
        public void Configure(EntityTypeBuilder<SalesLine> builder)
        {
            builder.Property(u => u.SalesHeaderId)
                .IsRequired();

            builder.Property(u => u.ItemId)
                .IsRequired();

            builder.Property(u => u.QTY)
                .IsRequired();

            builder.Property(u => u.Price)
                .IsRequired()
                .HasPrecision(18, 2);
        }
    }
}
