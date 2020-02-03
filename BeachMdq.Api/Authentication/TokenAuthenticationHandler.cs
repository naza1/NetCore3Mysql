using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CrossCutting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BeachMdq.Api.Authentication
{
    public class TokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private static AppSettings _appSettings;

        public TokenAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IOptions<AppSettings> appSettings) 
            : base(options, logger, encoder, clock)
        {
            _appSettings = appSettings.Value;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var token))
            {
                return await Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
            }

            var tokenUserId = ValidateToken(token);

            if (tokenUserId == null)
            {
                return await Task.FromResult(AuthenticateResult.Fail($"Invalid token Key {token}"));
            }

            var identity = new ClaimsIdentity(nameof(TokenAuthenticationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }

        private static string ValidateToken(string token)
        {
            var principal = GetPrincipal(token);
            if (principal == null)
                return null;

            ClaimsIdentity identity;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            var userIdClaim = identity.FindFirst(ClaimTypes.Name);
            var userId = userIdClaim.Value;
            return userId;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;

                var key = Encoding.UTF8.GetBytes(_appSettings.Secret);

                var parameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                var principal = tokenHandler.ValidateToken(token, parameters, out _);
                
                return principal;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
