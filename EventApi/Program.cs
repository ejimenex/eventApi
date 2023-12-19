using EventApi;
using EventApi.Application.Contract;
using EventApi.Infrasestructure.Filters;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureService().ConfigurePipeline();
app.MapGet("/swagger", () => "Hello World!");



app.Run();
