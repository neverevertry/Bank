using Common.UnitOfWork;
using DataAccess.Contexts;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context) => _context = context;

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
