using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Technical_Challenge.Handlers
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly string _authKey;
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IConfiguration config) : base(options, logger, encoder, clock)
        {
            _authKey = config["AuthKey"]; // Can be retrieved from DB as well
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var auth = Request.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrEmpty(auth))
                return AuthenticateResult.Fail("Missing Authorization Header");
            else if (auth != _authKey)
                return AuthenticateResult.Fail("Invalud Authorization");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, auth)
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            return AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name));
        }
    }
}
