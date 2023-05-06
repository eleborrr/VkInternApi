using System.Security.Principal;

namespace VkInternApi.Services.Auth;

public class BasicAuthenticationClient: IIdentity
{
    public string? AuthenticationType { get; init; }
    public bool IsAuthenticated { get; init; }
    public string? Name { get; init; }
}