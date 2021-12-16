using Domain.Entities;
using Domain.Interface;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class EFOptionRepository : IOptionRepository
    {
        private ApplicationDbContext context;

        public EFOptionRepository(ApplicationDbContext cont) => context = cont;

        public async Task Add(Option option)
        {
            context.Options.Add(option);
            await context.SaveChangesAsync();
        }
    }
}
