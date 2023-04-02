﻿using Grand.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Authentication.Google
{
    public class EndpointProvider : IEndpointProvider
    {
        public void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute("Plugin.ExternalAuth.Google.SignInGoogle",
                 "google-signin-failed",
                 new { controller = "GoogleAuthentication", action = "GoogleSignInFailed" }
            );
        }
        public int Priority => 10;
    }
}
