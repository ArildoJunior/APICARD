using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICardFinal.Data;
using APICardFinal.Interface;
using APICardFinal.ViewModel;

namespace APICardFinal.Services
{
    public class CardService : IServiceCard
    {
        private readonly APICardFinalContext _context;
        public CardService(APICardFinalContext context)
        {
            _context = context;
        }
        public List<Card> GetCreditCardsByEmail(string email)
        {
            try
            {
                var creditCards = _context.Card.Where(e => e.Email == email).ToList();
                return creditCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public Card Save(Card card)
        {
            try
            {
                card.CardNumber = RandomCardNumberGenerator.GenerateMasterCardNumber();
                var creditCard = _context.Card.Add(card).Entity;
                _context.SaveChanges();
                return creditCard;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string genetareCard()
        {
            return "1222 44477 49922";
        }

        public List<Card> GetCardsByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
