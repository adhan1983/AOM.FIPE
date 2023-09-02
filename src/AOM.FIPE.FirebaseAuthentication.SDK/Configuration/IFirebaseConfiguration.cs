namespace AOM.FIPE.FirebaseAuthentication.SDK.Configuration
{
    public interface IFirebaseConfiguration
    {
        string IDENTITY_TOOLKIT_BASE_URL { get; set; }
        string SECURE_TOKEN_BASE_URL { get; set; }
        string PROJECT_KEY { get; set; }
    }
}