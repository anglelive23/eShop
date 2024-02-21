namespace eShop.API
{
    public static class APIServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            #region Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            #endregion

            #region Serilog
            builder.Host.UseSerilog();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            #endregion

            #region Cors
            builder.Services.AddCors();
            #endregion

            return services;
        }
    }
}
