using Domain.Entities;
using System;

namespace Application.Interfaces
{
    public interface IOperationService
    {
        Option AddInfoOption(Card card, decimal? sum);
    }
}
