﻿using Microsoft.AspNetCore.Routing;

namespace Grand.Infrastructure.Endpoints;

/// <summary>
///     Endpoints provider
/// </summary>
public interface IEndpointProvider
{
    /// <summary>
    ///     Gets a priority of endpoint provider
    /// </summary>
    int Priority { get; }

    /// <summary>
    ///     Register endpoint
    /// </summary>
    /// <param name="endpointRouteBuilder">Endpoint Route builder</param>
    void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder);
}