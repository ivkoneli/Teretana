using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TeretanaContext : DbContext
    {
        public DbSet<Clan> Clanovi {get;set;}

        public DbSet<Clanarina> Clanarine{get;set;}

        public DbSet<Trener> Treneri{get;set;}

        // public DbSet<Spoj> TreneriClanovi {get ;set;}

        public TeretanaContext(DbContextOptions options) :base(options)
        {

        }
    }
}