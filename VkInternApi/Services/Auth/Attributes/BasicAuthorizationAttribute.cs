using Microsoft.AspNetCore.Authorization;

namespace VkInternApi.Services.Auth.Attributes;

public class BasicAuthorizationAttribute: AuthorizeAttribute
{
    public BasicAuthorizationAttribute()
    {
        AuthenticationSchemes = BasicAuthenticationDefaults.AuthenticationScheme;
    }
}