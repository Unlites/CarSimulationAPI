using CarSimulationAPI.Services;
using CarSimulationAPI.Services.Pedal;

namespace CarSimulationAPI.Handler.Pedal
{
    public class PedalHandlerHttp : IPedalHandler, IHttpHandler
    {
        private readonly IPedalService _pedalService;

        public PedalHandlerHttp(IPedalService pedalService)
        {
            _pedalService = pedalService;
        }

        public void Register(WebApplication app)
        {
            app.MapPost("/pedal/gaz/{duration}", Gaz)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("Gaz")
                .WithTags("Pedal");

            app.MapPost("/pedal/break/{duration}", Break)
                .Produces(StatusCodes.Status204NoContent)
                .WithName("Break")
                .WithTags("Pedal");
        }
        public async Task Gaz(int duration)
        {
            await _pedalService.Gaz(duration);
        }

        public async Task Break(int duration)
        {
            await _pedalService.Break(duration);
        }
    }
}
