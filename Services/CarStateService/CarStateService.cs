using CarSimulationAPI.DAL.Models;
using CarSimulationAPI.DAL.Repository;

namespace CarSimulationAPI.Services.CarStateService
{
    public class CarStateService : ICarStateService
    {
        private readonly ICarStateRepository _repository;
        public CarStateService(ICarStateRepository repository)
        {
            _repository = repository;
        }
        public async Task<CarState> Get()
        {
            return await _repository.GetAsync();
        }

        public async Task Update(CarState carState)
        {
            await _repository.UpdateAsync(carState);
            await _repository.SaveAsync();
        }
    }
}
