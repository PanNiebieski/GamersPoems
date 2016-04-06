﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using GamersPoems.Services;

namespace GamersPoems
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messages.Hello());
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
