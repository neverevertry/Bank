using Application;
using Application.Interfaces;
using Bank.SecurityContext;
using Common.TimeProvider;
using Common.UnitOfWork;
using DataAccess.Contexts;
using DataAccess.UnitOfWork;
using Domain.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bank
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string ConString = @"Data Source = SPEED; Integrated Security = True; Initial Catalog = Bank; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConString));
            services.AddHttpContextAccessor();
            services.AddTransient<ICardRepository, EFCardRepository>();
            services.AddTransient<IOptionRepository, EFOptionRepository>();
            services.AddTransient<ICardServices, CardService>();
            services.AddTransient<IOptionService, OptionService>();
            services.AddTransient<ITimeProvider, TimeProvider>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<ISecurityContextRetriever, SecurityContextRetriever>();
            services.AddTransient<ISecurityContextRetriever, CardCookie>();
           // services.AddAuthentication("CardCookie").AddCookie("CardCookie", options => options.Cookie.Name = "CardCookie");
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Mapper.MapperProfile));
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/error");
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(options =>
                options.MapControllerRoute("default", "{controller=Card}/{action=Index}"));
           

            SeedDataUserCard.EnsurePopulated(app);
        }
    }
}
