using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class CardLogic
    {
        private IOptionRepository optionRepository;

        public CardLogic(IOptionRepository repo)
        {
            optionRepository = repo;
        }

        private void InfoOperation(Card card, decimal sum)
        {
            Option option = new Option { Card = card, CardId = card.CardId, DateOperation = DateTime.Now, Widthdraw = sum, OptionDescriptionId = 1 };
            optionRepository.AddOptione(option);
        }

        public void InfoOperation(Card card)
        {
            Option option = new Option { Card = card, CardId = card.CardId, DateOperation = DateTime.Now, OptionDescriptionId = 2 };
            optionRepository.AddOptione(option);
        }

        public bool PossibleWidthdraw(Card card, decimal sum)
        {
            if (card.CardBalance > sum)
            {
                InfoOperation(card,sum);
                card.CardBalance -= sum;
                return true;
            }
            return false;
        }

    }
}
