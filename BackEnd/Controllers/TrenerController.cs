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

        [Route("Treneri/{ime}/{prezime}")]
        [HttpGet]

        public async Task<ActionResult> VratiTrenere(string ime ,string prezime)
        {

            var treneri = await Context.Treneri
                .Where(p=> p.Ime == ime && p.Prezime == prezime)
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
                .ToListAsync();

            return Ok(treneri);
        }


    }
}