using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.Authentication
{
    public class UpdatePasswordRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
