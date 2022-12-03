using CarSimulationAPI.DAL.Models;

namespace CarSimulationAPI.DAL.Repository
{
    public interface ICarStateRepository
    {
        public Task<CarState> GetAsync();
        public Task UpdateAsync(CarState carState);
        public Task SaveAsync();
    }
}
