using CarSimulationAPI.DAL.Models;

namespace CarSimulationAPI.DAL
{
    public class CarStateDb : DbContext
    {
        public CarStateDb(DbContextOptions<CarStateDb> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CarState> CarState => Set<CarState>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarState>(builder =>
            {
                builder.ToTable("CarState").HasKey(x => x.Id);
                builder.HasData(new CarState
                {
                    Id = 1,
                    TurnedOn = false,
                    Speed = 0,
                    LightsOn = false
                });
            });
        }
    }
}
