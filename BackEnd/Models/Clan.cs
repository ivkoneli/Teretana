using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Clan")]
    public class Clan
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string  Ime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prezime { get; set; }

        [RegularExpression("[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,}")]  // email regex 
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }


        public Trener trener {get;set;}   // Clan ima jednog trenera 

        public Clanarina clanarina {get;set;} // Clan ima jednu clanarinu

    }
}