
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
 
namespace OnlineShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
            services.AddSingleton<IProductsRepository,ProductsInMemoryRepository>();
            services.AddSingleton<ICartsRepository, CartsInMemoryRepository>();
            services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
            services.AddControllersWithViews();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
           
            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();

            app.UseRouting();
            //http://localhost:5001/hello/start

            app.UseEndpoints(endpoints =>
            {
                

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
