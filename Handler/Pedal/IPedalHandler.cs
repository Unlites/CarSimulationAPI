namespace CarSimulationAPI.Handler.Pedal
{
    public interface IPedalHandler
    {
        public Task Gaz(int duration);
        public Task Break(int duration);
    }
}
