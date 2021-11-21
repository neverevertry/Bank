using Bank.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string ConString = @"Data Source = SPEED; Integrated Security = True; Initial Catalog = Bank; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConString));
            services.AddTransient<ICardRepository, EFCardRepository>();
            services.AddTransient<IOptionRepository, EFOptionRepository>();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseEndpoints(options => options.MapControllerRoute("default","{controller=Card}/{action=Index}"));

            SeedDataUserCard.EnsurePopulated(app);
        }
    }
}
