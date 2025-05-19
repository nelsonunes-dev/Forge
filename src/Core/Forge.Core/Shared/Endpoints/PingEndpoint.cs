using FastEndpoints;
using Microsoft.AspNetCore.Builder;

namespace Forge.Core.Shared.Endpoints;

/// <summary>
/// A simple endpoint to check the health of the API.
/// </summary>
public class PingEndpoint : EndpointWithoutRequest
{
    /// <summary>
    /// Configures the endpoint with HTTP GET method and a route of "/ping".
    /// </summary>
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("/ping");
        AllowAnonymous();
        Description(x => x.WithName("HealthCheck"));
    }

    /// <summary>
    /// Handles the request and sends a response indicating the API is online.
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new { status = "online" }, cancellation: ct);
    }
}
