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


        [Route("PrikaziSveTermineClanova/{idteretane}")]
       [HttpGet]

       public async Task<ActionResult> VratiTermine(int idteretane)
       {
           var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
            var termini = await Context.Termini
            .Where(p=> p.teretana == teretana)
           .Include(p=> p.trener)
           .Include(p=> p.clan)
           .Include(p=> p.teretana)
           .ToListAsync();

            var termin = termini.Select(p=> 
            new
            {
                idtermina = p.ID,
                teretana = p.teretana.ID,
                clan = p.clan.ID,                              
                trener = p.trener.ID,                
                                
                pocetakTermina = p.pocetakTermina,
                krajTermina = p.krajTermina,                           
            });
           
           return Ok(termin);
       }
       [Route("PrikaziTermineClana/{ime}/{prezime}/{email}")]
       [HttpGet]

       public async Task<ActionResult> VratiTermine(string ime ,string prezime,string email)
       {
           var termini = await Context.Termini.Where(p=> p.clan.Email == email)
           .Include(p=> p.clan)
           .ThenInclude(p=> p.trener)
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
       [Route("PrikaziTermineTrenera{imeTrenera}/{prezimeTrenera}")]
       [HttpGet]
        public async Task<ActionResult> VratiTrenere(string imeTrenera ,string prezimeTrenera)
       {
           var treneri = await Context.Treneri.Where(p=> p.Ime == imeTrenera && p.Prezime == prezimeTrenera)
           .Include(p=> p.termini)
           .ThenInclude(p=> p.clan)
           .Include(p=> p.teretana)
           .ToListAsync();

           var trener = treneri.Select(p=>
           new
           {
               ime = p.Ime,
               prezime = p.Prezime,
               teretana  = p.teretana.Naziv,
        
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

       [Route("DodajTermin/{imeC}/{prezimeC}/{email}/{pocetakTermina}/{idteretane}")]
       [HttpPost]

       public async Task<ActionResult> DodajTermin(string imeC ,string prezimeC ,string email , DateTime pocetakTermina, int idteretane)
       {
           try
            {
                var clan = await Context.Clanovi.Where(p => p.Email == email && p.Ime == imeC && p.Prezime == prezimeC).FirstOrDefaultAsync();
                if (clan == null ){
                    return BadRequest("Nepostojeci clan !");
                }
                else
                {                       
                       var trener = await Context.Treneri.Where(p => p.Clanovi.Contains(clan) == true).FirstOrDefaultAsync();
                       var teretana = await Context.Teretana.Where( p=> p.ID == idteretane).FirstOrDefaultAsync();

                    Termin t  = new Termin
                    {
                        teretana = teretana,
                        clan = clan,
                        trener = trener,
                        pocetakTermina = pocetakTermina,
                        krajTermina = pocetakTermina,
                    };

                    Context.Termini.Add(t);
                    await Context.SaveChangesAsync();
                    return Ok($"Novi termin u {t.teretana.Naziv} je dodat sa pocetkum u {t.pocetakTermina} i zavrsava se u {t.krajTermina}");

                }
              
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
       }
    }
}
