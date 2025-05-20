using FastEndpoints;
using Forge.Persistence.Common.Abstractions;
using Forge.Persistence.Common.ReadModels;
using Forge.ScoreTracking.Requests;
using Forge.ScoreTracking.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.ScoreTracking.Endpoints;

/// <summary>
/// Endpoint for getting the score of a match.
/// </summary>
public class GetScoreEndpoint : Endpoint<GetScoreRequest, GetScoreResponse>
{
    private readonly IRepository<ScoreReadModel> _scoreReadModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetScoreEndpoint"/> class.
    /// </summary>
    /// <param name="scoreReadModel"></param>
    public GetScoreEndpoint(IRepository<ScoreReadModel> scoreReadModel)
    {
        _scoreReadModel = scoreReadModel;
    }

    /// <summary>
    /// Configures the endpoint.
    /// </summary>
    public override void Configure()
    {
        Get("/scores/{matchId}");
        AllowAnonymous();
    }

    /// <summary>
    /// Handles the request to get the score of a match.
    /// </summary>
    /// <param name="req"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public override async Task HandleAsync(GetScoreRequest req, CancellationToken ct)
    {
        var model = await _scoreReadModel.GetAsync(req.MatchId, ct);

        if (model is null)
        {
            await SendNotFoundAsync();
            return;
        }

        await SendAsync(new GetScoreResponse
        {
            MatchId = model.Id,
            Score = model.TotalScore
        });
    }
}
