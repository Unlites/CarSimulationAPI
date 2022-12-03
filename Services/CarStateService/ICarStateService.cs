using CarSimulationAPI.DAL.Models;

namespace CarSimulationAPI.Services.CarStateService
{
    public interface ICarStateService
    {
        public Task<CarState> Get();
        public Task Update(CarState carState);
    }
}
