using System.Security.Principal;

namespace VkInternApi.Services.Auth;

public class BasicAuthenticationClient: IIdentity
{
    public string? AuthenticationType { get; }
    public bool IsAuthenticated { get; }
    public string? Name { get; }
}