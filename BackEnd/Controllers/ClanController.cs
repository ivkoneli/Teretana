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
    public class ClanController : ControllerBase
    {

       public TeretanaContext Context{get;set;} 
       public ClanController(TeretanaContext context){
           Context = context ;
       }
    
        [Route("PreuzmiClana/{idteretane}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClana(int idteretane){
            

            var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
            var clanovi = await Context.Clanovi
            .Where(p=> p.teretana == teretana)
            .Include(p=> p.trener)
            .Include(p=> p.clanarina)
            .Include(p=> p.teretana)
            .ToListAsync();

            var clan = clanovi.Select(p=>
            new{
                id = p.ID,
                teretana = p.teretana.ID,
                ime = p.Ime,
                prezime = p.Prezime,
                email = p.Email,
                clanarina = p.clanarina.ID,
                trener = p.trener.ID,
            });
        

            return Ok(clan);
        }
        [Route("PreuzmiClanaE/{idteretane}/{email}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanaPoMejlu(int idteretane,string email){
            

                var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
                var clanovi = await Context.Clanovi.Where(p=> p.teretana == teretana && p.Email == email).FirstOrDefaultAsync();

                if (clanovi == null){
                    return Ok("Novi clan");
                }
                else if(clanovi != null){
                    return BadRequest("Korisnik vec postoji");
                }
                else {
                    return BadRequest("muda");
                }

        }
        [Route("PreuzmiClanaC/{clanarinaID}/{idteretane}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanapoClanarini(int clanarinaID,int idteretane){
            
            var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
            var clanovi = await Context.Clanovi.Where(p=> p.clanarina.ID == clanarinaID && p.teretana == teretana)
            .Include(p=> p.trener)
            .Include(p=> p.clanarina)
            .Include(p=> p.teretana)
            .ToListAsync();

            var clan = clanovi.Select(p=>
            new{
                id = p.ID,
                teretana = p.teretana.ID,
                ime = p.Ime,
                prezime = p.Prezime,
                email = p.Email,   
                clanarina = p.clanarina.ID,                         
                trener = p.trener.ID,
            });
        
            return Ok(clan);
        }
        [Route("PreuzmiClanaT/{trenerID}/{idteretane}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanapoTreneru(int trenerID,int idteretane){
            
            var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
            var clanovi = await Context.Clanovi.Where(p=> p.trener.ID == trenerID && p.teretana == teretana)
            .Include(p=> p.trener)
            .Include(p=> p.clanarina)
            .Include(p=> p.teretana)
            .ToListAsync();

            var clan = clanovi.Select(p=>
            new{
                id = p.ID,
                teretana = p.teretana.ID,
                ime = p.Ime,
                prezime = p.Prezime,
                email = p.Email,   
                clanarina = p.clanarina.ID,                         
                trener = p.trener.ID,
            });
             return Ok(clan);
        }


        [Route("Uclani/{ime}/{prezime}/{email}/{idtrenera}/{idclanarine}/{idteretane}")]
        [HttpPost]
        public async Task<ActionResult> Uclani([FromRoute] string ime ,string prezime , string email ,int idtrenera ,int idclanarine,int idteretane)
        {
            try
            { 
                var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
                var clanovi = await Context.Clanovi.Where(p=> p.Email == email && p.teretana == teretana).FirstOrDefaultAsync();
                var trener = await Context.Treneri.Where(p=> p.ID == idtrenera).FirstOrDefaultAsync();
                var clanarina = await Context.Clanarine.Where(p=> p.ID == idclanarine).FirstOrDefaultAsync();
                    if (trener == null || clanarina == null)
                    {
                        return BadRequest("Wtf si upravo probao ti lice ???");
                    }
                    else
                    {
                        Clan c = new Clan
                        {   
                            teretana = teretana,
                            Ime = ime,
                            Prezime= prezime,
                            Email = email,
                            trener = trener,
                            clanarina = clanarina,
                        };
                
                        if (clanovi != null){
                            return BadRequest("Clan vec postoji !");
                        }
                        else{                            
                            Context.Clanovi.Add(c);
                            await Context.SaveChangesAsync();
                            return Ok($"Clan je uclanjen ID je : {c.ID}");
                        }
                    }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniClanarinu/{ime}/{prezime}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniClana(string ime,string prezime,[FromBody]Clanarina clanarina)
        {
            try
            {
                var clan = Context.Clanovi.Where(p => p.Ime == ime && p.Prezime == prezime).FirstOrDefault();
                if (clan !=null)
                {         
                    clan.clanarina = clanarina; 

                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno promenjena clanarina u {clanarina.Naziv}" );
                }
                else
                {
                    return BadRequest("Nepostojeci clan");
                }
            }
            catch   (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PromeniTrenera/{ime}/{prezime}")]
        [HttpPut]

        public async Task<ActionResult> PromeniTrenera(string ime ,string prezime , [FromForm] Trener trener)
        {
            try
            {   
                var clan = Context.Clanovi.Where(p => p.Ime == ime && p.Prezime == prezime).FirstOrDefault();
                if (clan !=null)
                {         
                    clan.trener = trener;

                    await Context.SaveChangesAsync();
                    return Ok($"Uspesno promenjen trener u  {trener.Ime}" );
                }
                else
                {
                    return BadRequest("Nepostojeci clan");
                }

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("IzbrisiClana/{ime}/{prezime}/{email}/{idteretane}")]
        [HttpDelete]

        public async Task<ActionResult> IzbrisiClana(string ime ,string prezime ,string email ,int idteretane){

            var teretana = await  Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
            var clan = await Context.Clanovi.Where(p=> p.Email == email && p.teretana == teretana).FirstOrDefaultAsync();
            //var terminiclana = await Context.Termini.Where(p=> p.clan == clan ).FirstOrDefaultAsync();

            foreach (var  termin in Context.Termini.Where(t=> t.clan == clan))
            {
                Context.Termini.Remove(termin);

            }


            if (clan == null){
                return BadRequest("Nepostojeci clan !");
            }
            else{               
                Context.Clanovi.Remove(clan);
                await Context.SaveChangesAsync();
                return Ok($"Clan sa ID-em : {clan.ID} je obrisan !");
            }

        }
    }
}
