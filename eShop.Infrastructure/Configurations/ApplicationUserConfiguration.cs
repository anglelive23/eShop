namespace eShop.Infrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
