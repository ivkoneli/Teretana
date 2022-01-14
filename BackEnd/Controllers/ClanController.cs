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
    
        [Route("PreuzmiClana")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClana(){
            
            var clanovi = await Context.Clanovi
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
        [Route("PreuzmiClanaC/{clanarinaID}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanapoClanarini(int clanarinaID){
            
            var clanovi = await Context.Clanovi.Where(p=> p.clanarina.ID == clanarinaID)
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
        [Route("PreuzmiClanaT/{trenerID}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiClanapoTreneru(int trenerID){
            
            var clanovi = await Context.Clanovi.Where(p=> p.trener.ID == trenerID)
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
                var clanovi = await Context.Clanovi.Where(p=> p.Email == email).FirstOrDefaultAsync();
                var trener = await Context.Treneri.Where(p=> p.ID == idtrenera).FirstOrDefaultAsync();
                var clanarina = await Context.Clanarine.Where(p=> p.ID == idclanarine).FirstOrDefaultAsync();
                var teretana = await Context.Teretana.Where(p=> p.ID == idteretane).FirstOrDefaultAsync();
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
    }
}
