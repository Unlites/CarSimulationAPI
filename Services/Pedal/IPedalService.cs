namespace CarSimulationAPI.Services.Pedal
{
    public interface IPedalService
    {
        public Task Gaz(int duration);
        public Task Break(int duration);
    }
}
