using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{


    public class Clanarina 
    {
        [Key]
        public int ID { get; set; }


        [MaxLength(20)]
        public string Naziv { get; set; }

        
        public int Cena { get; set; }

    }

}