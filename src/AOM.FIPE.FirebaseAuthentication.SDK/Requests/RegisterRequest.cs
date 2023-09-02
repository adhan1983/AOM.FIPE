using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOM.FIPE.FirebaseAuthentication.SDK.Http
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken => true;
    }
}
