using CarSimulationAPI.DAL.Models;

namespace CarSimulationAPI.Handler.CarStateHandler
{
    public interface ICarStateHandler
    {
        public Task<CarState> Get();
        public Task Update(CarState carState);
    }
}
