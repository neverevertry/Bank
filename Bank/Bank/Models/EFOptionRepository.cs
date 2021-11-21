using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class EFOptionRepository : IOptionRepository
    {
        private ApplicationDbContext context;

        public EFOptionRepository(ApplicationDbContext cont) => context = cont;

        public void AddOptione(Option option)
        {
            context.Options.Add(option);
            context.SaveChanges();
        }
    }
}
