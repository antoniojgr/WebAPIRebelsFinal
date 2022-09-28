
using WebAPIRebels;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Logging.AddConsole();


var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();



startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.


app.Run();
