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
    public class TeretanaController : ControllerBase
    {

       public TeretanaContext Context{get;set;} 
       public TeretanaController(TeretanaContext context){
           Context = context ;
       }


       [Route("VratiSveClanove/{idteretane}")]
       [HttpGet]

       public async Task<ActionResult> VratiSveClanove(int idteretane){

            var clanovi = await Context.Teretana
            .Where(p=> p.ID == idteretane)
            .Include(p=> p.clanovi)
            .Include(p=> p.treneri)
            .Include(p=> p.clanarine)
            .ToListAsync();
         

            var clan = clanovi.Select(p=>
            new{
               idteretane = p.ID,
               naziv = p.Naziv,
               ListaClanova = clanovi.Select(q=>
               new{
                   ime = q.clanovi.Select(c=>
                   new{
                       ime = c.Ime,
                       prezime = c.Prezime,
                       email = c.Email,
                       clanarina = c.clanarina.Naziv,
                       TrenerI = c.trener.Ime,
                       TrenerP = c.trener.Prezime,
                   })
               })

            });
            return Ok(clan);
       }

       [Route("Teretane")]
       [HttpGet]

       public async Task<ActionResult> VratiSveTeretane(){


           var teretane = await Context.Teretana.ToListAsync();
           

           var teretana = teretane.Select(p=>
           new{
               id = p.ID,
               naziv = p.Naziv,
           });

           return Ok(teretana);
       }
    }
}