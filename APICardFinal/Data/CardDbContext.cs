using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICardFinal.Models;

namespace APICardFinal.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Card> Cards { get; set; }
        public string GenerateCardNumber()
        {
            Random rand = new Random();
            String sRandomResult = "";
            for (int i = 0; i < 16; i++)
            {
                sRandomResult += rand.Next(9).ToString();
            }
            return sRandomResult;
        }
    }
}