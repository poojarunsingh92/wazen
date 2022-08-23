using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WazenIdentity.Application.Contracts.Identity;
using WazenIdentity.Application.Models.Authentication;
using WazenIdentity.Application.Responses;
using WazenIdentity.Identity.Models;

namespace WazenIdentity.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IdentityDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private IPasswordHasher<ApplicationUser> _passwordHasher;
        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IdentityDbContext context, RoleManager<ApplicationRole> roleManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }

        //public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);
        //    var roles = await _userManager.GetRolesAsync(user);
        //    AuthenticationResponse response = new AuthenticationResponse();

        //    if (user == null)
        //    {
        //        response.IsAuthenticated = false;
        //        response.Message = $"No Accounts Registered with {request.Email}.";
        //        return response;
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

        //    if (!result.Succeeded)
        //    {
        //        throw new AuthenticationException($"Credentials for '{request.Email} aren't valid'.");
        //    }

        //    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        //    if (user.RefreshTokens.Any(a => a.IsActive))
        //    {
        //        var activeRefreshToken = user.RefreshTokens.FirstOrDefault(a => a.IsActive);
        //        response.RefreshToken = activeRefreshToken.Token;
        //        response.RefreshTokenExpiration = activeRefreshToken.Expires;
        //    }
        //    else
        //    {
        //        var refreshToken = GenerateRefreshToken();
        //        response.RefreshToken = refreshToken.Token;
        //        response.RefreshTokenExpiration = refreshToken.Expires;
        //        user.RefreshTokens.Add(refreshToken);
        //        _context.Update(user);
        //        _context.SaveChanges();
        //    }

        //    response.IsAuthenticated = true;
        //    response.Id = user.Id;
        //    response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        //    response.Email = user.Email;
        //    response.Role = roles[0];
        //    response.UserName = user.UserName;

        //    return response;
        //}

        //public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        //{
        //    var existingUser = await _userManager.FindByNameAsync(request.UserName);

        //    if (existingUser != null)
        //    {
        //        throw new ArgumentException($"Username '{request.UserName}' already exists.");
        //    }

        //    var user = new ApplicationUser
        //    {
        //        Email = request.Email,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        UserName = request.UserName,
        //        EmailConfirmed = true,
        //        RoleId = Guid.Parse("cb1adaf4-1df4-4b55-addc-53516ffabbf2")
        //    };

        //    var existingEmail = await _userManager.FindByEmailAsync(request.Email);

        //    if (existingEmail == null)
        //    {
        //        var result = await _userManager.CreateAsync(user, request.Password);

        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(user, "CUSTOMER");
        //            return new RegistrationResponse() { UserId = user.Id };
        //        }
        //        else
        //        {
        //            throw new Exception($"{result.Errors}");
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Email {request.Email } already exists.");
        //    }
        //}
        public async Task<AuthenticationAdminResponse> AdminAuthenticateAsync(AdminAuthenticationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            AuthenticationAdminResponse response = new AuthenticationAdminResponse();

            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Invalid email or password.";
                response.Errors = "Invalid Credentials";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response.IsAuthenticated = false;
                response.Message = $"Invalid email or password.";
                response.Errors = "Invalid Credentials";
                return response;
            }
            else
            {
                var roleName = await _userManager.GetRolesAsync(user);
                var roleId = await _roleManager.FindByNameAsync(roleName[0]);


                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                if (user.RefreshTokens.Any(a => a.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(a => a.IsActive);
                    response.RefreshToken = activeRefreshToken.Token;
                    response.RefreshTokenExpiration = activeRefreshToken.Expires;
                }
                else
                {
                    var refreshToken = GenerateRefreshToken();
                    response.RefreshToken = refreshToken.Token;
                    response.RefreshTokenExpiration = refreshToken.Expires;
                    user.RefreshTokens.Add(refreshToken);
                    _context.Update(user);
                    _context.SaveChanges();
                }
                //AzureServer
                RestClient client = new RestClient("http://admin.wazen.ml/api/v1/User/GetUserByUserId?UserId=" + user.Id);

                //Server
                //RestClient client = new RestClient("http://180.149.247.134:9093/api/v1/User/GetUserByUserId?UserId=" + user.Id);

                //Local
                //RestClient client = new RestClient("http://localhost:60810/api/v1/User/GetUserByUserId?UserId=" + user.Id);

                var requestIdentityRegister = new RestRequest(Method.GET);
                string newResponse = "";
                requestIdentityRegister.AddHeader("Content-Type", "application/json");

                IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
                if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getRegisterResponse.Content;
                }
                var adminResponse = JsonSerializer.Deserialize<AdminResponse>(newResponse);

                response.Succeeded = true;
                response.Message = "success";
                response.Errors = null;
                response.IsAuthenticated = true;
                var userData = new UserDetails()
                {
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Roles = new Application.Models.Authentication.Role() { RoleId = roleId.Id.ToString(), RoleName = roleName[0] }
                };

                var adminData = new AdminData()
                {

                    id = adminResponse.id,
                    contactNo = adminResponse.contactNo,
                    designation = adminResponse.designation,
                    isActive = adminResponse.isActive

                };

                response.userAdmin = new UserAdmin();
                response.userAdmin.userDetails = userData;
                response.userAdmin.adminData = adminData;
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            return response;
        }
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            AuthenticationResponse response = new AuthenticationResponse();

            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Invalid email or password.";
                response.Errors = "Invalid Credentials";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                response.IsAuthenticated = false;
                response.Message = $"Invalid email or password.";
                response.Errors = "Invalid Credentials";
                return response;
            }
            else
            {
                var roleName = await _userManager.GetRolesAsync(user);
                var roleId = await _roleManager.FindByNameAsync(roleName[0]);


                JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

                if (user.RefreshTokens.Any(a => a.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(a => a.IsActive);
                    response.RefreshToken = activeRefreshToken.Token;
                    response.RefreshTokenExpiration = activeRefreshToken.Expires;
                }
                else
                {
                    var refreshToken = GenerateRefreshToken();
                    response.RefreshToken = refreshToken.Token;
                    response.RefreshTokenExpiration = refreshToken.Expires;
                    user.RefreshTokens.Add(refreshToken);
                    _context.Update(user);
                    _context.SaveChanges();
                }

                //AzureServer
                RestClient client = new RestClient("http://customer.wazen.ml/api/v1/Customer/GetCustomerByUserId?Userid=" + user.Id);

                //Server
                //RestClient client = new RestClient("http://180.149.247.134:8095/api/v1/Customer/GetCustomerByUserId?Userid=" + user.Id);

                //Local
                //RestClient client = new RestClient("http://localhost:54806/api/v1/Customer/GetCustomerByUserId?Userid="+ user.Id);

                var requestIdentityRegister = new RestRequest(Method.GET);
                string newResponse = "";
                requestIdentityRegister.AddHeader("Content-Type", "application/json");

                //var identityReq = new CustomerRequest()
                //{
                //    UserId =Guid.Parse(user.Id)
                //};
                //var body = JsonSerializer.Serialize(identityReq);
                //requestIdentityRegister.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse getRegisterResponse = client.Execute(requestIdentityRegister);
                if (getRegisterResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    newResponse = getRegisterResponse.Content;
                }
                var customerResponse = JsonSerializer.Deserialize<CustomerResponse>(newResponse);

                response.Succeeded = true;
                response.Message = "success";
                response.Errors = null;
                response.IsAuthenticated = true;
                var userData = new UserDetials()
                {
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Role = new Application.Models.Authentication.Role() { RoleId = roleId.Id.ToString(), RoleName = roleId.Name.ToString() }
                };
                var customerData = new CustomerData()
                {
                    id = customerResponse.id,
                    DateOfBirth = customerResponse.DateOfBirth

                };

                response.Data = new User();
                response.Data.UserData = userData;
                response.Data.CustomerData = customerData;
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            return response;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            RegistrationResponse registrationResponse = new RegistrationResponse();
            try
            {
                var existingUser = await _userManager.FindByNameAsync(request.UserName);

                if (existingUser != null)
                {
                    registrationResponse.UserId = null;
                    return registrationResponse;
                }

                var user = new ApplicationUser
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    EmailConfirmed = true
                };

                var existingEmail = await _userManager.FindByEmailAsync(request.Email);

                if (existingEmail == null)
                {
                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (result.Succeeded)
                    {
                        var roleId = await _roleManager.FindByNameAsync(request.RoleName);

                        await _userManager.AddToRoleAsync(user, request.RoleName);
                        return new RegistrationResponse() { UserId = user.Id, RoleId = roleId.Id };
                    }
                    else
                    {
                        registrationResponse.UserId = null;
                        registrationResponse.RoleId = null;
                        return registrationResponse;
                    }
                }
                else
                {
                    registrationResponse.UserId = null;
                    registrationResponse.RoleId = null;

                    return registrationResponse;
                }
            }
            catch (Exception ex)
            {
                registrationResponse.UserId = null;
                registrationResponse.RoleId = null;

                return registrationResponse;
            }
        }




        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var response = new RefreshTokenResponse();
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.Token));
            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token did not match any users.";
                return response;
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (!refreshToken.IsActive)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token Not Active.";
                return response;
            }

            //Revoke Current Refresh Token
            refreshToken.Revoked = DateTime.UtcNow;

            //Generate new Refresh Token and save to Database
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            _context.Update(user);
            await _context.SaveChangesAsync();

            //Generates new jwt
            response.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.Expires;
            return response;
        }

        public async Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request)
        {
            var response = new RevokeTokenResponse();
            if (string.IsNullOrEmpty(request.Token))
            {
                response.IsRevoked = false;
                response.Message = "Token is required";
                return response;
            }

            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.Token));

            if (user == null)
            {
                response.IsRevoked = false;
                response.Message = "Token did not match any users";
                return response;
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);
            if (!refreshToken.IsActive)
            {
                response.IsRevoked = false;
                response.Message = "Token is not active";
                return response;
            }
            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            _context.Update(user);
            await _context.SaveChangesAsync();
            response.IsRevoked = true;
            response.Message = "Token revoked";
            return response;
        }
        public async Task<UpdateResetPasswordResponse> ChangePassword(UpdateResetPasswordRequest updateResetPasswordRequest)
        {
            UpdateResetPasswordResponse updateResetPasswordResponse = new UpdateResetPasswordResponse();
            //var user = await _userManager.FindByNameAsync(updateResetPasswordRequest.username); // if u want to update with the user name 
            var user = await _userManager.FindByEmailAsync(updateResetPasswordRequest.Email);
            if (user == null)
            {
                updateResetPasswordResponse.Succeeded = false;
                updateResetPasswordResponse.Message = "User Not Found";
                updateResetPasswordResponse.Errors = null;
                updateResetPasswordResponse.Data = null;
                return updateResetPasswordResponse;
            }
            var passwordHash = _passwordHasher.HashPassword(user, updateResetPasswordRequest.NewPassword);
            user.PasswordHash = passwordHash;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                updateResetPasswordResponse.Succeeded = false;
                updateResetPasswordResponse.Message = "Password Reset Successfully";
                updateResetPasswordResponse.Errors = null;
                updateResetPasswordResponse.Data = null;
                return updateResetPasswordResponse;
            }
            await _signInManager.RefreshSignInAsync(user);
            updateResetPasswordResponse.Succeeded = true;
            updateResetPasswordResponse.Message = "Password Reset Successfully";
            updateResetPasswordResponse.Errors = null;
            updateResetPasswordResponse.Data = null;
            return updateResetPasswordResponse;
        }

        //UpdatePassword
        public async Task<UpdatePasswordResponse> UpdatePassword(UpdatePasswordRequest updatePasswordRequest)
        {
            UpdatePasswordResponse updatePasswordResponse = new UpdatePasswordResponse();
            //var user = await _userManager.FindByNameAsync(updateResetPasswordRequest.username); // if u want to update with the user name 
            var user = await _userManager.FindByEmailAsync(updatePasswordRequest.Email);
            if (user == null)
            {
                updatePasswordResponse.Succeeded = false;
                updatePasswordResponse.Message = "User Not Found";
                updatePasswordResponse.Errors = null;
                updatePasswordResponse.Data = null;
                return updatePasswordResponse;
            }

            PasswordVerificationResult isSuccess1 = PasswordVerificationResult.Failed;
            isSuccess1 = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, updatePasswordRequest.Password);

            if (isSuccess1.ToString() == "Success")
            {
                PasswordVerificationResult isSuccess2 = PasswordVerificationResult.Failed;
                isSuccess2 = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, updatePasswordRequest.NewPassword);
                if (isSuccess2.ToString() == "Success")
                {
                    updatePasswordResponse.Succeeded = true;
                    updatePasswordResponse.Message = "Please enter different password.";
                    updatePasswordResponse.Errors = null;
                    updatePasswordResponse.Data = null;
                    return updatePasswordResponse;
                }
                var passwordHash = _passwordHasher.HashPassword(user, updatePasswordRequest.NewPassword);
                user.PasswordHash = passwordHash;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    updatePasswordResponse.Succeeded = false;
                    updatePasswordResponse.Message = "Password Not Updated Successfully";
                    updatePasswordResponse.Errors = null;
                    updatePasswordResponse.Data = null;
                    //return updatePasswordResponse;
                }
                await _signInManager.RefreshSignInAsync(user);
                updatePasswordResponse.Succeeded = true;
                updatePasswordResponse.Message = "Password Updated Successfully";
                updatePasswordResponse.Errors = null;
                updatePasswordResponse.Data = null;
                //return updatePasswordResponse;
            }
            else
            {
                updatePasswordResponse.Succeeded = false;
                updatePasswordResponse.Message = "Invalid Password! Please Enter Correct Password";
                updatePasswordResponse.Errors = null;
                updatePasswordResponse.Data = null;
            }
            return updatePasswordResponse;
        }

        public async Task<Response<UpdateEmailResponse>> UpdateProfile(UpdateEmailRequest updateEmailRequest)
        {
            Response<UpdateEmailResponse> updateEmailResponse = new Response<UpdateEmailResponse>();
            var user = await _userManager.FindByIdAsync(updateEmailRequest.UserId.ToString());

            if (user == null)
            {
                updateEmailResponse.Succeeded = false;
                updateEmailResponse.Message = "User Not Found";
                updateEmailResponse.Errors = null;
                updateEmailResponse.Data = null;
                return updateEmailResponse;
            }

            user.Email = updateEmailRequest.Email;
            user.FirstName = updateEmailRequest.FirstName;
            user.LastName = updateEmailRequest.LastName;
            user.NormalizedEmail = updateEmailRequest.Email.ToUpper();
            user.UserName = updateEmailRequest.Email;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                updateEmailResponse.Succeeded = true;
                updateEmailResponse.Message = "Email Update Successfully";
                updateEmailResponse.Errors = null;
                updateEmailResponse.Data = new UpdateEmailResponse()
                {
                    Email = updateEmailRequest.Email,
                    FirstName = updateEmailRequest.FirstName,
                    LastName = updateEmailRequest.LastName,
                    UserName = updateEmailRequest.UserName
                };
                return updateEmailResponse;
            }
            return updateEmailResponse;
        }
    }
}