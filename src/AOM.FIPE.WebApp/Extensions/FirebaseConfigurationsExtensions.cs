using AOM.FIPE.FirebaseAuthentication.SDK.Configuration;

namespace AOM.FIPE.WebApp.Extensions
{
    public static class FirebaseConfigurationsExtensions
    {
        public static FirebaseConfiguration BuildingFirebaseConfigurations(IConfiguration configuration)
        {            
                var settings = configuration.GetSection("FirebaseConfiguration");

                FirebaseConfiguration firebaseConfiguration = new FirebaseConfiguration();
                {
                    firebaseConfiguration.PROJECT_KEY = settings.GetValue<string>("PROJECT_KEY");
                    firebaseConfiguration.SECURE_TOKEN_BASE_URL = settings.GetValue<string>("SECURE_TOKEN_BASE_URL");
                    firebaseConfiguration.IDENTITY_TOOLKIT_BASE_URL = settings.GetValue<string>("IDENTITY_TOOLKIT_BASE_URL");
                }

                return firebaseConfiguration;
            
        }
    }
}
