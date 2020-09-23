using System.Linq;
using API.Errors;
using API.Extensions;
using API.helpers;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //addScoped is duration we want the depedency to available for use.
            services.AddControllers();
            services.AddApplicationServices();
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddSwaggerDocumentation();//custom extension for IServiceCollection
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<middlewares.ExceptionMiddleware>(); //custom middleware
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.AddSwaggerMiddleware();// custome extention for IApplicationBuilder
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
