namespace CarSimulationAPI.DAL.Models
{
    public class CarState
    {
        public int Id { get; set; }
        public bool TurnedOn { get; set; }
        public int Speed { get; set; }
        public bool LightsOn { get; set; }
    }
}
