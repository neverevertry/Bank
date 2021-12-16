using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;

namespace Application
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly ITimeProvider _timeProvider;

        public OptionService(IOptionRepository optionRepository, ITimeProvider timeProvider)
        {
            _optionRepository = optionRepository;
            _timeProvider = timeProvider;
        }

        public Option Log(int cardId, decimal? sum, int optionDescriptionId)
        {
            Option opt = new Option { CardId = cardId,  
                                      DateOperation = _timeProvider.Now,
                                      OptionDescriptionId  = optionDescriptionId, 
                                      Widthdraw = sum 
                                    };
            _optionRepository.Add(opt);
            return opt;
        }
    }
}
