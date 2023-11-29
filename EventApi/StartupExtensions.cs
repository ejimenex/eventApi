﻿using EventApi.Application;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure;
using EventApi.Percistence;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
namespace EventApi
{
    public static class StartupExtensions
    {
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Event Api"
                });
            });

        }
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);
            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
            });
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Activities>("Activities");
            builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));
            builder.Services.AddApplicationServices();
            builder.Services.AddInfraestructureServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            return builder.Build();

        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("Open");
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.MapControllers();
            return app;
        }
    }
}
