using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICardFinal.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string NumberCard { get; set; }
        public int UsuarioID { get; set; }
    }
}