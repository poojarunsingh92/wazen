using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.Authentication
{
  public   class AdminAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
