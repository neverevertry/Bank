using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IOptionRepository
    {
        Task AddOptione(Option option);
    }
}
