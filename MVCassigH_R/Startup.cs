using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVCassigH_R
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
            services.AddControllersWithViews(); // less then but enoth for the basic, use for more advance ->
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); // tvinga att blir allt i https lägge
            }
            app.UseHttpsRedirection(); // tvinga till https 
            app.UseStaticFiles(); // vilken ordeniung det kommer det är viktigt ..  den läser uppifrån till ner...

            app.UseRouting();

            app.UseAuthorization(); // hanterrar av inloggnig 

            app.UseEndpoints(endpoints => //lägger den ordrningen som den skall köras , behöver bara ett att  köra ...
            {
                endpoints.MapControllerRoute(
                    // andra sett att den skall se ut ..specialfall
                    name: "special",
                    pattern: "Another/way",
                   defaults: new { controller = "Home", action = "HiddenPath" }
                   );


                endpoints.MapControllerRoute(
                    // andra sett att den skall se ut ..specialfall
                    name: "specialStage2", // ändra i lägg till i HomeController.cs filiken
                    pattern: "Secret/{action=Index}",
                    defaults: new { controller = "Lost" }
                  );
                // det skall vara längst ner default ..
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // nyckel ord på innan för fiskmåsarna.. id extra innmatning.. 

            });
        }
    }
}
