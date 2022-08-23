using System.Threading.Tasks;
using WazenIdentity.Application.Models.Authentication;
using WazenIdentity.Application.Responses;

namespace WazenIdentity.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationAdminResponse> AdminAuthenticateAsync(AdminAuthenticationRequest request);
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request);
        Task<UpdateResetPasswordResponse> ChangePassword(UpdateResetPasswordRequest updateResetPasswordRequest);
        Task<UpdatePasswordResponse> UpdatePassword(UpdatePasswordRequest updatePasswordRequest);
        Task<Response<UpdateEmailResponse>> UpdateProfile(UpdateEmailRequest updateEmailRequest);
    }
}
