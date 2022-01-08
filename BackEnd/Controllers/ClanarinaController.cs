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

        [Route("Clanarine/{naziv}")]
        [HttpGet]

        public async Task<ActionResult> VratiClanarine(string naziv)
        {
            
            var clanarine = await  Context.Clanarine
                    .Where(p=> p.Naziv == naziv)
                   .Include(p=> p.ClanoviClanarine)
                   .ToListAsync();
            return Ok(clanarine);
        }

        [Route("Clanarine")]
        [HttpGet]

        public async Task<ActionResult> VratiSveClanarine()
        {
            var clanarine = await Context.Clanarine
            .Include(p=> p.ClanoviClanarine)
            .ToListAsync();
            return Ok(clanarine);
        }

    }
}