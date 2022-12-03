using CarSimulationAPI.DAL.Models;
using CarSimulationAPI.Services.CarStateService;

namespace CarSimulationAPI.Handler.CarStateHandler
{
    public class CarStateHandlerHttp : ICarStateHandler, IHttpHandler
    {
        private readonly ICarStateService _service;
        public CarStateHandlerHttp(ICarStateService service)
        {
            _service = service;
        }

        public void Register(WebApplication app)
        {
            app.MapGet("/car_state/", Get)
                .Produces<CarState>(StatusCodes.Status200OK)
                .WithName("Get")
                .WithTags("CarState");
            app.MapPut("/car_state", Update)
                .Accepts<CarState>("application/json")
                .Produces(StatusCodes.Status204NoContent)
                .WithName("Update")
                .WithTags("CarState");
        }

        public async Task<CarState> Get()
        {
            return await _service.Get();
        }

        public async Task Update(CarState carState)
        {
            await _service.Update(carState);
        }
    }
}
