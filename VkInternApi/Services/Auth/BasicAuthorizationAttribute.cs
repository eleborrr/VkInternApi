using Microsoft.AspNetCore.Authorization;

namespace VkInternApi.Services.Auth;

public class BasicAuthorizationAttribute: AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
    }
}