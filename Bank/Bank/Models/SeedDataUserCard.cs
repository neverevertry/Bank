using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Bank.Models
{
    public class SeedDataUserCard 
    {
        public static void EnsurePopulated (IApplicationBuilder app)
        {
            ApplicationDbContext dbcontext = app.ApplicationServices.CreateScope().ServiceProvider.GetService < ApplicationDbContext>();
            dbcontext.Database.Migrate();

            if (!dbcontext.Cards.Any())
            {
                dbcontext.Cards.AddRange
                    (
                    new Card { CardNumb = "1111111111111111", CardBalance = 250M, CardBanned = false, Password = "test" },
                    new Card { CardNumb = "2111111111111111", CardBalance = 2250M, CardBanned = true, Password = "test" },
                    new Card { CardNumb = "3111111111111111", CardBalance = 2310M, CardBanned = true, Password = "test" },
                    new Card { CardNumb = "4111111111111111", CardBalance = 1150M, CardBanned = false, Password = "test" }
                    );
                dbcontext.optionDescriptions.AddRange(new OptionDescription { Descrtiptions = "Widthdraw" }, new OptionDescription { Descrtiptions = "Balance" });
            }
            dbcontext.SaveChanges();
        }
    }
}
