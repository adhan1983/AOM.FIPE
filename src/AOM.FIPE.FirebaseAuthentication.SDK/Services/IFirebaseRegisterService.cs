using Refit;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public interface IFirebaseRegisterService
    {
        [Post("/v1/accounts:signUp")]
        Task<RegisterResponse> Register([Body] RegisterRequest registerRequest);
    }
}
