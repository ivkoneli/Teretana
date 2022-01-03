using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Trener 
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Prezime { get; set; }

        [Required]
        [Range(25000,150000)]
        public int Plata { get; set; }

        

    }

}