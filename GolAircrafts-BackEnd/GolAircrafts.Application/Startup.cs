using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GolAirCrafts.Domain.Interfaces.Repositories;
using GolAirCrafts.Domain.Interfaces.Services;
using GolAirCrafts.Infra.Data.Context;
using GolAirCrafts.Infra.Data.Repository;
using GolAirCrafts.Service.Services;

namespace GolAirCrafts.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<ContextAzureDb>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddDbContext<ContextDb>(opt => opt.UseInMemoryDatabase("GolDb"));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IAirplaneService, AirplaneService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
