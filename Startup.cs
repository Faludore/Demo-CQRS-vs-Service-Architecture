using Autofac;
using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Repositories;
using DemoCQRSvsSevrice.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoCQRSvsSevrice
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddMediatR(typeof(DefaultContext).Assembly);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register<IDbContext>(c => new DefaultContext(_configuration.GetConnectionString("MSSQLConnection"))).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Comparation}/{action=Index}/{id?}");
            });
        }
    }
}
