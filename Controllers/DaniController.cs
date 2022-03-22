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
    public class DaniController : ControllerBase
    {       
        public MoviesContext Context {get; set;}

        public DaniController(MoviesContext context)
        { 
            Context = context;
        }  

        [Route("Dani")]
        [HttpGet]

        public async Task<ActionResult> Dani()
        {
            var dan = Context.Dani;
            return Ok(dan);
        }

        [Route("DaniFilm")]
        [HttpGet]
        public async Task<ActionResult> DaniFilm(int id)
        {
            var dani = Context.Dani.Where(p => p.IdDana == id)
            .Include(p=> p.FilmoviDani);
            return Ok(dani);
        }

        [Route("DaniPoIdu")]
        [HttpGet]
        public async Task<ActionResult> DaniPoIdu(int id)
        {
            var dani = Context.Dani.Where(p => p.IdDana == id);
            return Ok(dani);
        }

        [Route("Dodaj Dan")]
        [HttpPost]

        public async Task<ActionResult> DodajDan([FromBody] Dani Dani)
        {
            if(String.IsNullOrWhiteSpace(Dani.Naziv))
            {
                return BadRequest("Unesite Dan");
            }
            try
            {
                Context.Dani.Add(Dani);
                await Context.SaveChangesAsync();
                return Ok($"Dan sa nazivom: {Dani.Naziv} je dodat");
            }
            catch(Exception e)
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
                var dani = await Context.Dani.FindAsync(id);
                var nazivDana = dani.Naziv;
                Context.Dani.Remove(dani);
                await Context.SaveChangesAsync();
                return Ok($"Uspesno izbrisan dan: {nazivDana}");

            }
            catch(Exception e)
            {

            return BadRequest(e.Message);
            }
        }
      
    }
}
