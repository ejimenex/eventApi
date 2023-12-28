using EventApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureService().ConfigurePipeline();
app.MapGet("/swagger", () => "Hello World!");



app.Run();
