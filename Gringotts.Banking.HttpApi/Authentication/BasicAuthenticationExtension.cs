namespace Gringotts.Banking.HttpApi.Authentication;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

public static class BasicAuthenticationExtension
{
    public static void AddBasicAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<BasicAuthenticationOptions>(builder.Configuration.GetSection("BasicAuthenticationOptions"));

        builder.Services.AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
                "BasicAuthentication",
                options => { });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("BasicAuthentication", new AuthorizationPolicyBuilder("BasicAuthentication").RequireAuthenticatedUser().Build());
        });                       

    }
}