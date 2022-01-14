using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClanarinaController : ControllerBase
    {

       public TeretanaContext Context{get;set;} 
       public ClanarinaController(TeretanaContext context){
           Context = context ;
       }

        [Route("Clanarine/{idteretane}")]
        [HttpGet]

        public async Task<ActionResult> VratiClanarine(int idteretane)
        {
            
            var clanarine = await  Context.Teretana
            .Where(p=> p.ID == idteretane)
            .Include(p=> p.clanarine)
            .ToListAsync();

            var listaclanarina = clanarine.Select(p=>
            new {
                    Teretana = p.Naziv,
                    listaclanarina = p.clanarine.Select(q=>
                    new{
                        naziv = q.Naziv,
                    })
            });
       
            
            return Ok(listaclanarina);
        }

        [Route("Clanarine")]
        [HttpGet]

        public async Task<ActionResult> VratiSveClanarine()
        {
            var clanarine = await  Context.Clanarine
                   .Include(p=> p.ClanoviClanarine)
                   .Include(p=> p.teretana)
                   .ToListAsync();

            var clanarina = clanarine.Select(p=>
            new{
                id = p.ID,
                teretana = p.teretana.Naziv,
                naziv = p.Naziv,
                cena = p.Cena,
                clanovi =p.ClanoviClanarine.Select(q=>
                new{
                    ime = q.Ime,
                    prezime = q.Prezime,
                })
            });
            
            return Ok(clanarina);
        }

    }
}