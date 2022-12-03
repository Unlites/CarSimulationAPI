using CarSimulationAPI.DAL;
using CarSimulationAPI.DAL.Repository;
using CarSimulationAPI.Handler;
using CarSimulationAPI.Handler.CarStateHandler;
using CarSimulationAPI.Handler.Pedal;
using CarSimulationAPI.Services.CarStateService;
using CarSimulationAPI.Services.Pedal;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

var scope = app.Services.CreateScope();
var handlers = scope.ServiceProvider.GetServices<IHttpHandler>();
foreach (var handler in handlers)
{
    if (handler == null) throw new InvalidProgramException("Handler is not found");
    handler.Register(app);
}

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<CarStateDb>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    });

    services.AddScoped<ICarStateRepository, CarStateRepository>();
    services.AddScoped<ICarStateService, CarStateService>();
    services.AddScoped<IPedalService, PedalService>();
    services.AddScoped<IHttpHandler, CarStateHandlerHttp>();
    services.AddScoped<IHttpHandler, PedalHandlerHttp>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
}