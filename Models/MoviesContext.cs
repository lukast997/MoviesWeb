
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Bioskop> Bioskop {get;set;} 
        public DbSet<Dani> Dani {get;set;}
        public DbSet<Film> Film { get; set; }
        /*public DbSet<Spoj> ProdavnicaKategorija { get; set; }*/
        public MoviesContext(DbContextOptions options) : base(options)
        {

        }
    }
}