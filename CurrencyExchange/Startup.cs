using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.IO;
using CurrencyExchange.Domain.Repositories.Interfaces;
using CurrencyExchange.Domain.Repositories.EntityFramework;
using CurrencyExchange.Domain;
using Microsoft.Extensions.Logging;

namespace CurrencyExchange
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ????????? ???????????? ? ?????????????
            services.AddControllersWithViews()
                // ????????????? ? Asp.Net Core 3.0
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddLogging(loggingBuilder =>
            {
                //????? ? ???????
                loggingBuilder.AddConsole()
                //????? ?????? SQL
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);

                //????? ? ???? ???????
                loggingBuilder.AddDebug();
            });

            services.AddScoped<ICurrenciesOndateRepository, EFCurrenciesOndateRepository>();
            services.AddScoped<ICurrenciesRepository, EFCurrenciesRepository>();
            services.AddScoped<Storage>();

            // Connect to DataBase
            services.AddDbContext<AppDbContext>(x => x.UseSqlite(Configuration["ConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // ????????? ??????????? ??????
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
