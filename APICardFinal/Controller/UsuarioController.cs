using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICardFinal.Data;
using APICardFinal.Models;

namespace APICardFinal.Controllers
{
    public class UsuarioController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UsuariosController : ControllerBase
        {
            private readonly CardDbContext _context;

            public UsuariosController(CardDbContext context)
            {
                _context = context;
            }

            [HttpGet("{email}")]
            public async Task<ActionResult<Usuario>> GetUsuario(string email)
            {
                var usuario = await _context.Usuarios
                    .Include(c => c.Cards.OrderBy(o => o.Id))
                    .FirstOrDefaultAsync(b => b.Email == email);

                if (usuario == null)
                {
                    return NotFound();
                }
                return usuario;
            }

            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
            {
                var p = await _context.Usuarios.FirstOrDefaultAsync(b => b.Email == usuario.Email);
                if (p == null)
                {
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();
                    p = await _context.Usuarios.FirstOrDefaultAsync(b => b.Email == usuario.Email);
                }

                Random rand = new Random();
                Card c = new Card();
                c.NumberCard = _context.GenerateCardNumber();
                c.UsuarioID = p.Id;
                _context.Cards.Add(c);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsuario", new { email = p.Email }, p);
            }
        }
    }
}