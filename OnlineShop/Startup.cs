
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using Serilog;
 
namespace OnlineShop.Areas.Admin
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
            string connection = Configuration.GetConnectionString("online_shop");
            services.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(connection));

            services.AddSingleton<IOrdersRepository, OrdersInMemoryRepository>();
            services.AddTransient<IProductsRepository,ProductsDbRepository>();
            services.AddSingleton<ICartsRepository, CartsInMemoryRepository>();
            services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
            services.AddSingleton<IUsersManager, UsersManager>();
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
                    name: "Area",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
