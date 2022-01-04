using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Spoj
    {
        [Key]
        public int ID { get; set; }

        public Clan Clan {get;set;}


        public Clanarina Clanarina {get;set;}
        
        public Trener Trener{get;set;}



    }
}