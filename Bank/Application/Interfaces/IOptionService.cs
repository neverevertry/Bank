using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOptionService
    {
        Option AddInfoOption(Card card, decimal? sum);
    }
}
