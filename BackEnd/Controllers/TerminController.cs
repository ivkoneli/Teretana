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
                ime = p.Ime,
                prezime = p.Prezime,
                brojkartice =p.BrKartice,
                email = p.Email,
               // clanarina = p.clanarina.Naziv,
                trenerI = p.trener.Ime,
                trenerP = p.trener.Prezime,
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

       [Route("DodajTermin/{imeC}/{prezimeC}/{brKartice}/{imeT}/{prezimeT}/{pocetakT}/{krajT}")]
       [HttpPost]

       public async Task<ActionResult> DodajTermin(string imeC ,string prezimeC ,
        int brKartice ,string imeT ,string prezimeT , DateTime pocetakT , DateTime krajT)
       {
           try
            {
                var clan = await Context.Clanovi.Where(p => p.BrKartice == brKartice).FirstOrDefaultAsync();
                var trener = await Context.Treneri.Where(p => p.Ime == imeT && p.Prezime == prezimeT).FirstOrDefaultAsync();

                Termin t  = new Termin
                {
                    pocetakTermina = pocetakT,
                    krajTermina = krajT,
                    trener = trener,
                    clan = clan
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
