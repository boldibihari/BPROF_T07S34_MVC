using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NationalChampionship.Data.Models;
using NationalChampionship.Logic.Classes;
using NationalChampionship.Logic.Interfaces;
using NationalChampionship.Repository.Classes;
using NationalChampionship.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IAdministratorLogic, AdministratorLogic>();
            services.AddTransient<IUserLogic, UserLogic>();

            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();

            services.AddDbContext<NationalChampionshipDbContext>();
            services.AddTransient<DbContext, NationalChampionshipDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
