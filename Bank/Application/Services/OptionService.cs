using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;
using System;

namespace Application
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository optionService;
        public OptionService(IOptionRepository option)
        {
            optionService = option;
        }

        public Option AddInfoOption(Card card, decimal? sum)
        {
            Option opt = new Option { Card = card, CardId = card.CardId, DateOperation = DateTime.Now,OptionDescriptionId  = sum.HasValue? 2: 1, Widthdraw = sum };
            optionService.AddOptione(opt);
            return opt;
        }
    }
}
