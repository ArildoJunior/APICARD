using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICardFinal.ViewModel;

namespace APICardFinal.Data
{
    public class APICardFinalContext : DbContext
    {
        public APICardFinalContext (DbContextOptions<APICardFinalContext> options)
            : base(options)
        {
        }

        public DbSet<APICardFinal.ViewModel.Card> Card { get; set; }
    }
}
