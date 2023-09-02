using System.Text.Json.Serialization;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public class RefreshResponse
    {
        [JsonPropertyName("id_token")]
        public string IdToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }
    }
}
