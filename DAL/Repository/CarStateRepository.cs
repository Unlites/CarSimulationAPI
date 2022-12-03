using CarSimulationAPI.DAL.Models;

namespace CarSimulationAPI.DAL.Repository
{
    public class CarStateRepository : ICarStateRepository
    {
        private readonly CarStateDb _context;
        public CarStateRepository(CarStateDb context)
        {
            _context = context;
        }
        public async Task<CarState> GetAsync() =>
           await _context.CarState.FirstAsync();

        public async Task UpdateAsync(CarState carState)
        {
            var dbCarState = await _context.CarState.FirstAsync();
            dbCarState.TurnedOn = carState.TurnedOn;
            dbCarState.LightsOn = carState.LightsOn;
            dbCarState.Speed = carState.Speed;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
