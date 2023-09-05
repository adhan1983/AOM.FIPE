namespace AOM.FIPE.WebApp.Extensions
{
    public static class SessionsExtensions
    {
        public static IServiceCollection AddingSessionsExtensions(this IServiceCollection services) 
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
    }
}
