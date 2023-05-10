using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using VkInternApi.Data.Repositories;

namespace VkInternApi.Services.Auth;

public class BasicAuthorizationService: AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IRepositoryManager _repositoryManager;
    
    public BasicAuthorizationService(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IRepositoryManager repositoryManager) : base(options, logger, encoder, clock)
    {
        _repositoryManager = repositoryManager;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // No authorization header, so throw no result.
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Missing Authorization header"));
        }

        var authorizationHeader = Request.Headers["Authorization"].ToString();

        // If authorization header doesn't start with basic, throw no result.
        if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
        {
            return Task.FromResult(AuthenticateResult.Fail("Authorization header does not start with 'Basic'"));
        }

        // Decrypt the authorization header and split out the client id/secret which is separated by the first ':'
        var authBase64Decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationHeader.Replace("Basic ", "", StringComparison.OrdinalIgnoreCase)));
        var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);

        // No username and password, so throw no result.
        if (authSplit.Length != 2)
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization header format"));
        }

        // Store the client ID and secret
        var clientId = authSplit[0];
        var clientSecret = authSplit[1];


        // Check user with login in DB
        var userData = _repositoryManager.UserRepository.GetAllAsync().Result
            .FirstOrDefault(u => u.Login == clientId);
        if (userData is null)
        {
            return Task.FromResult(
                AuthenticateResult.Fail("Invalid login or password"));
        }
        
        // Client secret is incorrect
        if (clientSecret != userData.Password)
        {
            return Task.FromResult(
                AuthenticateResult.Fail("Invalid login or password"));
        }

        // Authenicate the client using basic authentication
        var client = new BasicAuthenticationClient
        {
            AuthenticationType = BasicAuthenticationDefaults.AuthenticationScheme,
            IsAuthenticated = true,
            Name = clientId
        };

        // Set the client ID as the name claim type.
        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
        {
            new Claim(ClaimTypes.Name, clientId)
        }));

        // Return a success result.
        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
    }
}