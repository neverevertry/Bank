using Domain.Entities;
using Domain.Interface;

namespace DataAccess.Contexts
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
