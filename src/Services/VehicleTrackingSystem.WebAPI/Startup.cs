using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using VehicleTrackingSystem.WebAPI.Data;
using VehicleTrackingSystem.WebAPI.Repository;
using VehicleTrackingSystem.WebAPI.Services;

namespace VehicleTrackingSystem.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(opts => opts.UseInMemoryDatabase("VehicleTrackingDb"));
            services.AddScoped<DatabaseContext>();
            services.AddControllers();
            services.AddMemoryCache();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IVehicleLocationRepository, VehicleLocationRepository>();
            services.AddTransient<IGMapLocationService, GMapLocationService>();
            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:5005";
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "deviceClient", "device_client"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VehicleTracking API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://dotnetcs.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "pramod pandit",
                        Email = string.Empty,
                        Url = new Uri("https://dotnetcs.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://dotnetcs.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
