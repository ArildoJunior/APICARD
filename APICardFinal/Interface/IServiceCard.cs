using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICardFinal.ViewModel;

namespace APICardFinal.Interface
{
    public interface IServiceCard
    {
        Card Save(Card card);
        List<Card> GetCardsByEmail(string email);
    }
}