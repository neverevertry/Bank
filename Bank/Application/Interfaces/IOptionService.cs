using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOptionService
    {
        Option Log(int cardId, decimal? sum, int optionDescriptionId);
    }
}
