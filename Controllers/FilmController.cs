using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Movies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {       
        public MoviesContext Context {get; set;}

        public FilmController(MoviesContext context)
        { 
            Context = context;
        }  
        
        [Route("Filmovi")]
        [HttpGet]

        public async Task<ActionResult> Filmovi()
        {
            var filmovi = Context.Film
            .Include(p => p.FilmDani);
            return Ok(filmovi);
        }

        [Route("FilmoviPoImenu")]
        [HttpGet]

        public async Task<ActionResult> FilmoviPoImenu(string naziv)
        {
            var filmovi = Context.Film.Where(p=> p.Naziv == naziv);
            return Ok(filmovi);
        }

        [Route("Dodaj Film")]
        [HttpPost]

        public async Task<ActionResult> DodajFilm([FromBody] Film Film)
        {
            if(String.IsNullOrWhiteSpace(Film.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            if(Film.Cena < 0)
            {
                return BadRequest("Unesite Cenu");
            }
            try
            {
                Context.Film.Add(Film);
                await Context.SaveChangesAsync();
                return Ok($"Film sa nazivom: {Film.Naziv} je dodat");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("Izmeni Film")]
        [HttpPut]

        public async Task<ActionResult> IzmeniFilm(int idFilma, Film Film)
        {
             if(String.IsNullOrWhiteSpace(Film.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
             if(Film.Cena < 0)
            {
                return BadRequest("Unesite Cenu");
            }

        try
        {
            var film = Context.Film.Where( p => p.IdFilma == idFilma).FirstOrDefault();
            String stariNaziv = film.Naziv;
            if(Film != null){
                film.Naziv = Film.Naziv;
                film.Cena = Film.Cena;
                film.Projekcija = Film.Projekcija;
                await Context.SaveChangesAsync();
                return Ok($"Film sa nazivom: {stariNaziv} je promenjana u { film.Naziv}");
            }
            else
            {
                return BadRequest("Molimo vas unesite film");
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        }
        
        [Route("Izbrisi")]
        [HttpDelete]
        public async Task<ActionResult> Izbrisi(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Pogresan ID");
            }
            try
            {
                var film = await Context.Film.FindAsync(id);
                var nazivFilma = film.Naziv;
                Context.Film.Remove(film);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izbrisan film: {nazivFilma}");

            }
            catch(Exception e)
            {

            return BadRequest(e.Message);
            }
        }
      
    }
}
