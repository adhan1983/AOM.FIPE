using Refit;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public interface IFirebaseLoginService
    {
        [Post("/v1/accounts:signInWithPassword")]
        Task<LoginResponse> Login([Body] LoginRequest loginRequest);
    }
}
