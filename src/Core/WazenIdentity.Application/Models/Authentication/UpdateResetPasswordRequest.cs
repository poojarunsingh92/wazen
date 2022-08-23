using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WazenIdentity.Application.Models.Authentication
{
    public class UpdateResetPasswordRequest
    {
        public string Email { get; set; }
       
        public string NewPassword { get; set; }
    }
}
