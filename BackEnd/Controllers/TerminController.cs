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
    public class TerminController : ControllerBase
    {

       public TeretanaContext Context{get;set;} 
       public TerminController(TeretanaContext context){
           Context = context ;
       }


        [Route("PrikaziSveTermineClanova")]
       [HttpGet]

       public async Task<ActionResult> VratiTermine()
       {
            var termini = await Context.Termini
           .Include(p=> p.trener)
           .Include(p=> p.clan)
           .ToListAsync();

            var termin = termini.Select(p=> 
            new
            {
                idtermina = p.ID,
                clan = p.clan.ID,                              
                trener = p.trener.ID,                
                                
                pocetakTermina = p.pocetakTermina,
                krajTermina = p.krajTermina,
                

                             
            });
           
           return Ok(termin);
       }
       [Route("PrikaziTermineClana{ime}/{prezime}/{email}")]
       [HttpGet]

       public async Task<ActionResult> VratiTermine(string ime ,string prezime,string email)
       {
           var clanovi = await Context.Clanovi.Where(p=> p.Ime == ime && p.Prezime == prezime && p.Email == email)
           .Include(p=> p.termin)
           .ThenInclude(p=> p.trener)
           .ToListAsync();

            var clan = clanovi.Select(p=> 
            new
            {
                clan = p.ID,                              
                trener = p.trener.ID,                
                termin = p.termin.Select(q=>
                new 
                {
                    pocetakTermina = q.pocetakTermina,
                    krajTermina = q.krajTermina,
                })

                             
            });
           
           return Ok(clan);
       }
       [Route("PrikaziTermineTrenera{imeTrenera}/{prezimeTrenera}")]
       [HttpGet]
        public async Task<ActionResult> VratiTrenere(string imeTrenera ,string prezimeTrenera)
       {
           var treneri = await Context.Treneri.Where(p=> p.Ime == imeTrenera && p.Prezime == prezimeTrenera)
           .Include(p=> p.termini)
           .ThenInclude(p=> p.clan)
           .ToListAsync();

           var trener = treneri.Select(p=>
           new
           {
               ime = p.Ime,
               prezime = p.Prezime,
               brojlicence = p.brLicence,
               
               termin = p.termini.Select(q=>
               new
               {
                   imeClana = q.clan.Ime,
                   PrezimeClana = q.clan.Prezime,
                   pocetakTermina = q.pocetakTermina,
                   krajTermina = q.krajTermina,
               })
           });

           
           return Ok(trener);
       }

       [Route("DodajTermin/{imeC}/{prezimeC}/{email}/{pocetakTermina}")]
       [HttpPost]

       public async Task<ActionResult> DodajTermin(string imeC ,string prezimeC ,string email , DateTime pocetakTermina)
       {
           try
            {
                var clan = await Context.Clanovi.Where(p => p.Email == email).FirstOrDefaultAsync();
                var trenerID = clan.trener.ID;
                var trener = await Context.Treneri.Where(p => p.ID == trenerID).FirstOrDefaultAsync();

                Termin t  = new Termin
                {
                    clan = clan,
                    trener = trener,
                    pocetakTermina = pocetakTermina,
                    krajTermina = pocetakTermina,
                };

                Context.Termini.Add(t);
                await Context.SaveChangesAsync();
                return Ok($"Novi termin je dodat sa pocetkum u {t.pocetakTermina} i zavrsava se u {t.krajTermina}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
       }
    }
}
