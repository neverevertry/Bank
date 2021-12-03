using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOperationService
    {
        Option AddInfoOption(Card card, decimal? sum);
    }
}
