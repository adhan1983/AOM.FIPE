using AOM.FIPE.FirebaseAuthentication.SDK.Configuration;
using AOM.FIPE.FirebaseAuthentication.SDK.Http;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Extensions
{
    public static class FirebaseAuthenticationSDKHostBuilderExtensions
    {       
        public static IServiceCollection AddFirebaseAuthenticationSDK(this IServiceCollection services, FirebaseConfiguration firebaseConfiguration)
        {
            services.AddTransient<FirebaseApiKeyHttpMessageHandler>(s => new FirebaseApiKeyHttpMessageHandler(firebaseConfiguration.PROJECT_KEY));

            services.AddRefitClient<IFirebaseRegisterService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(firebaseConfiguration.IDENTITY_TOOLKIT_BASE_URL))
                .AddHttpMessageHandler<FirebaseApiKeyHttpMessageHandler>();

            services.AddRefitClient<IFirebaseLoginService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(firebaseConfiguration.IDENTITY_TOOLKIT_BASE_URL))
                .AddHttpMessageHandler<FirebaseApiKeyHttpMessageHandler>();

            services.AddRefitClient<IFirebaseRefreshService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(firebaseConfiguration.SECURE_TOKEN_BASE_URL))
                .AddHttpMessageHandler<FirebaseApiKeyHttpMessageHandler>();

            return services;
        }
    }
}
