namespace eShop.Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.UOMId)
                .IsRequired();

            builder.Property(u => u.QTY)
                .IsRequired();

            builder.Property(u => u.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
