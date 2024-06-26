using Grpc.Core;

namespace Monotaur.Plugins.Dummy.Services;

public class ProbeService : Probe.ProbeBase
{
    private readonly ILogger<ProbeService> _logger;
    public ProbeService(ILogger<ProbeService> logger)
    {
        _logger = logger;
    }

    public override Task<ProbeResultResponse> ProbeResult(ProbeResultRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ProbeResultResponse
        {
            Message = "Hello " + request.Id
        });
    }
}
