using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Teretana")]
    public class Teretana
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(12)]
        public string Naziv { get; set; }

        [JsonIgnore]
        public List<Trener> treneri {get;set;}   

        [JsonIgnore]
        public List<Clanarina> clanarine {get;set;} 
    
        [JsonIgnore]
        public List<Clan> clanovi {get;set;} 

    }
}