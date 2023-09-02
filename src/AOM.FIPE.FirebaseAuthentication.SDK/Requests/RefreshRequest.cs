using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public class RefreshRequest
    {
        [AliasAs("refresh_token")]
        public string RefreshToken { get; set; }

        [AliasAs("grant_type")]
        public string GrantType => "refresh_token";
    }
}
