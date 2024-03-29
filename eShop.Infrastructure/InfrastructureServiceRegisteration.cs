﻿namespace eShop.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext
            services.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<eShopContext>();
            services.AddDbContext<eShopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region JWT
            services.Configure<JWT>(configuration.GetSection(nameof(JWT)));
            services.AddScoped<IAuthService, AuthService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"] ?? "OdkSeYWNl/ECZJaRsjzTqQ9rGb7jp0Ovp57idk1LeGs=")),
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            #region Repositories
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<ISalesOrdersService, SalesOrdersService>();
            services.AddScoped<IPriceCalculator, PriceCalculator>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            #endregion

            return services;
        }
    }
}
