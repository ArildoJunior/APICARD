using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APICardFinal.ViewModel
{
    public class Card
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite um email.")]
        [RegularExpression(@"!#$%&'*+-/=?^_`{|}~", ErrorMessage = "Não é um email, corrija o campo")]
        public string name { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }

        public Card(string email)
        {
            this.Email = email;
            this.CardNumber = RandomCardNumberGenerator.GenerateMasterCardNumber();
        }
    }
}