using EShop.BLL.Mapping;
using EShop.BLL.Services;
using EShop.BLL.Services.Inerfaces;
using EShop.BLL.Validations;
using EShop.DAL.Data;
using EShop.DAL.Repository;
using EShop.DAL.Repository.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.WebAPI
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

            Log.Logger = new LoggerConfiguration().MinimumLevel.Error().WriteTo.Console()
             .WriteTo.File("Log/log-.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
                opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddAutoMapper(typeof(CustomMapping));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
            services.AddControllers();
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ProductValidation>());
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(typeof(ProductValidation).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EShop.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EShop.WebAPI v1"));
            }

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
