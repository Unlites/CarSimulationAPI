using CarSimulationAPI.DAL.Repository;

namespace CarSimulationAPI.Services.Pedal
{
    public class PedalService : IPedalService
    {
        private readonly ICarStateRepository _carStateRepository;

        public PedalService(ICarStateRepository carStateRepository)
        {
            _carStateRepository = carStateRepository;
        }

        public async Task Gaz(int duration)
        {   
            var gainingSpeed = duration * 10; // Let's imagine that car is gaining 10 km/h on 1 sec
            var carState = await _carStateRepository.GetAsync();
            carState.Speed += gainingSpeed;
            if (carState.Speed > 220)
            {
                carState.Speed = 220;
            }

            await _carStateRepository.UpdateAsync(carState);
        }

        public async Task Break(int duration)
        {
            var losingSpeed = duration * 30; // Let's imagine that car is losing 30 km/h on 1 sec
            var carState = await _carStateRepository.GetAsync();
            carState.Speed -= losingSpeed;
            if (carState.Speed < 0)
            {
                carState.Speed = 0;
            }

            await _carStateRepository.UpdateAsync(carState);
        }
    }
}
