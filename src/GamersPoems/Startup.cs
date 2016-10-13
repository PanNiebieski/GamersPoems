using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using GamersPoems.Services;
using GamersPoems.Services.Interface;
using Microsoft.AspNet.Routing;

namespace GamersPoems
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IGamesData, GamesData>();
            services.AddSingleton<IMessages, Messages>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment enviroment,
            IMessages messages)
        {
            app.UseIISPlatformHandler();

            if (enviroment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseRuntimeInfoPage("/info");
                app.UseWelcomePage("/IIS");
            }

            app.UseStaticFiles();

            app.UseMvc(SetRoutes);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messages.Hello());
            });
        }

        private void SetRoutes(IRouteBuilder routeBuilder)
        {
            // Home / Index
            routeBuilder.MapRoute("MyDefault", 
                "{controller=Home}/{action=Index}/{id?}");
        }




        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
