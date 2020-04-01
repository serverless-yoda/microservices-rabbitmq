using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RMQ.Infrastructure.IoC;
using RMQ.Transfer.Data.Context;

namespace RMQ.Transfer.API
{
    public class Startup
    {
        private const string SWAGGER_TITLE = "RabbitMQ Microservice Transfer System";

        private void RegisterServices(IServiceCollection services)
        {
            DIContainer.RegisterServices(services);
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TransferDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("TransferDbConnection"));
            });

            services.AddControllers();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = SWAGGER_TITLE,
                    Version = "v1"
                });
            });
            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", SWAGGER_TITLE + " v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           

        }
    }
}
