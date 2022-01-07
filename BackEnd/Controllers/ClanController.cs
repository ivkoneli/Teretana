using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            
            return Ok(Context.Clanovi);
        }


        [Route("Uclani")]
        [HttpPost]
        public async Task<ActionResult> Uclani([FromBody] Clan clan)
        {
            try
            {
                Context.Clanovi.Add(clan);
                await Context.SaveChangesAsync();
                return Ok($"Clan je uclanjen ID je : {clan.ID}");
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
