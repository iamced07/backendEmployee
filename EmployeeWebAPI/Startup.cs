using core.Response;
using core.Services;
using data.Repository;
using Entity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Scaffold-dbContext "Server=DESKTOP-L440QEA;Initial Catalog=EmployeeDB;User ID=user1;Password=password" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context EmployeeContext -t dbo.Department, dbo.Employee -f
namespace EmployeeWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            cnString = Configuration["ConnectionStrings:DbaseCn"];
        }

        public IConfiguration Configuration { get; }
        public string cnString { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IgeneralModel, generalModel>();
            services.AddScoped<IgeneralResponse, generalResponse>();
            services.AddControllers();
            services.AddDbContext<EmployeeContext>(i => i.UseSqlServer(cnString));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
