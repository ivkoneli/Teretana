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
    
        [Route("PreuzmiClana/{id}")]
        [HttpGet]

        public async Task<ActionResult> PreuzmiClana(int id){
            
            return Ok("Bravo");
        }
    }
}
