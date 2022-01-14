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
    public class TrenerController : ControllerBase
    {

       public TeretanaContext Context{get;set;} 
       public TrenerController(TeretanaContext context){
           Context = context ;
       }

        [Route("Treneri/{idtrenera}")]
        [HttpGet]

        public async Task<ActionResult> VratiTrenere(int idtrenera)
        {

            var treneri = await Context.Treneri
                .Where(p=> p.ID == idtrenera)
                .Include(p => p.Clanovi)
                .ToListAsync();

            return Ok(treneri);
        }

        [Route("Treneri")]
        [HttpGet]

        public async Task<ActionResult> VratiSveTrenere()
        {

            var treneri =await Context.Treneri               
                .Include(p => p.Clanovi)
                .ThenInclude(p=> p.clanarina)
                .ToListAsync();

            var trener = treneri.Select(p=>
            new{
                id = p.ID,
                brLicence = p.brlicence,
                teretana = p.teretana,
                ime = p.Ime,
                prezime =p.Prezime,
                plata = p.Plata,
                clanovi =p.Clanovi.Select(q=>
                new{
                    ime = q.Ime,
                    prezime = q.Prezime,
                    clanarina = q.clanarina.Naziv
                })

            });

            return Ok(trener);
        }


    }
}