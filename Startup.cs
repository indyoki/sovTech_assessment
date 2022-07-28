using ChuckSwapi.Brokers;
using ChuckSwapi.Brokers.Interfaces;
using ChuckSwapi.Components;
using ChuckSwapi.Components.Interfaces;
using ChuckSwapi.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChuckSwapi
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped<IChuckBroker, ChuckBroker>();
            services.AddScoped<IChuckLogic, ChuckLogic>();
            services.AddScoped<ISWBroker, SWBroker>();
            services.AddScoped<ISWLogic, SWLogic>();
            services.AddScoped<ILogger<ChuckController>, Logger<ChuckController>>();
            services.AddScoped<ILogger<SwapiController>, Logger<SwapiController>>();
            services.AddScoped<ILogger<SearchController>, Logger<SearchController>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
