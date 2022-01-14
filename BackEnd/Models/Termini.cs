using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;

namespace Models
{
    [Table("Termini")]
    public class Termin
    {

        public  int  ID { get; set; }

        public DateTime pocetakTermina {get;set;}

        public  DateTime krajTermina {get;set;}

        public Trener trener {get;set;}

        public Clan clan{get;set;}

        public Teretana teretana{get;set;}

    }
}