using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Trener 
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int brlicence { get; set; }


        [Required]
        [MaxLength(20)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prezime { get; set; }

        [Required]
        [Range(25000,150000)]
        public int Plata { get; set; }

        public List<Clan> Clanovi {get;set;}  //Trener ima nekoliko clanova 

        public List<Termin> termini {get;set;} // Trener ima listu svojih termina 
        
        public Teretana teretana{get;set;} // Trener ima jednu teretanu

    }

}