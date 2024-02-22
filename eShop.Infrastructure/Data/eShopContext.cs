namespace eShop.Infrastructure.Data
{
    public class eShopContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructors
        public eShopContext(DbContextOptions<eShopContext> options) : base(options) { }
        #endregion

        #region DBSets
        public DbSet<Item> Items { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<SalesLine> SalesLines { get; set; }
        public DbSet<SalesHeader> SalesHeaders { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(eShopContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles", "security");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users", "security");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims", "security");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims", "security");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins", "security");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles", "security");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", "security");

            modelBuilder.Entity<RefreshToken>()
                .ToTable("RefreshTokens", "security");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<ApplicationUser>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
