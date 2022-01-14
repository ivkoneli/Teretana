using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{


    public class Clanarina 
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(20)]
        public string Naziv { get; set; }

        
        public int Cena { get; set; }

        
        public List<Clan> ClanoviClanarine {get;set;}   // vise clanova poseduju jednu vrstu clanarine

        public Teretana teretana{get;set;}
        

    }

}