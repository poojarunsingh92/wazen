using System;
using System.Collections.Generic;
using System.Text;

namespace WazenIdentity.Application.Models.Authentication
{
    public class UpdateResetPasswordResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string? Errors { get; set; }
        public string? Data { get; set; }
    }
}
