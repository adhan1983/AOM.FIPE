﻿namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public class LoginResponse
    {
        public string IdToken { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
    }
}
