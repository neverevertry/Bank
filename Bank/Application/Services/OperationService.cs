using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;
using System;

namespace Application
{
    public class OperationService : IOperationService
    {
        IOptionRepository optionService;
        public OperationService(IOptionRepository operation)
        {
            optionService = operation;
        }

        public Option AddInfoOption(Card card, decimal? sum)
        {
            if (sum == null)
            {
                Option opt = new Option { Card = card, CardId = card.CardId, DateOperation = DateTime.Now,OptionDescriptionId = 2 };
                optionService.AddOptione(opt);
                return opt;
            }
            else
            {
                Option option = new Option { Card = card, CardId = card.CardId, DateOperation = DateTime.Now, Widthdraw = (decimal)sum, OptionDescriptionId = 1 };
                optionService.AddOptione(option);
                return option;
            }
        }
    }
}
