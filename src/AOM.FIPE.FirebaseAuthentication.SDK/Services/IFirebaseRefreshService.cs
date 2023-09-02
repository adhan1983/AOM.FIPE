using Refit;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public interface IFirebaseRefreshService
    {
        [Post("/v1/token")]
        Task<RefreshResponse> Refresh([Body(BodySerializationMethod.UrlEncoded)] RefreshRequest refreshRequest);
    }
}
