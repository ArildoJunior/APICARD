using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICardFinal.Models
{
    public class Usuario
    {
		public int Id { get; set; }
		public string nome { get; set; }
		public string Email { get; set; }
		public virtual ICollection<Card> Cards { get; set; }
	}
}