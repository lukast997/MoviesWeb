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
    public class BioskopController : ControllerBase
    {
        public MoviesContext Context {get; set;}

        public BioskopController(MoviesContext context)
        { 
            Context = context;
        }  
        
        [Route("SviBioskopi")]
        [HttpGet]

        public async Task<ActionResult> SviBioskopi()
        {
            return Ok(Context.Bioskop);
        }

        [Route("BioskopPoIdu")]
        [HttpGet]

        public async Task<ActionResult> BioskopPoIdu(int id)
        {
            var bioskop = Context.Bioskop.Where( p => p.IdBioskopa == id);
            return Ok(bioskop);
        }

        [Route("BioskopiPoDanima")]
        [HttpGet]

        public async Task<ActionResult> BioskopiPoDanima(int index)
        {
            var bioskopi = Context.Bioskop.Where(p => p.IdBioskopa == index)
            .Include( p=> p.DaniBioskop);
            return Ok(bioskopi);
        }
        
        [Route("Dodaj Bioskop")]
        [HttpPost]

        public async Task<ActionResult> DodajBioskop([FromBody] Bioskop Bioskop)
        {
            if(String.IsNullOrWhiteSpace(Bioskop.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            if(String.IsNullOrWhiteSpace(Bioskop.Adresa))
            {
                return BadRequest("Unesite Naziv");
            }
            try
            {
                Context.Bioskop.Add(Bioskop);
                await Context.SaveChangesAsync();
                return Ok($"Bioskop sa nazivom: {Bioskop.Naziv} je dodat");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Izmeni Bioskop")]
        [HttpPut]

        public async Task<ActionResult> IzmeniBioskop(int IdBioskopa, Bioskop Bioskop)
        {
             if(String.IsNullOrWhiteSpace(Bioskop.Naziv))
            {
                return BadRequest("Unesite Naziv");
            }
            if(String.IsNullOrWhiteSpace(Bioskop.Adresa))
            {
                return BadRequest("Unesite Naziv");
            }

        try
        {
            var bioskop = Context.Bioskop.Where( p => p.IdBioskopa == IdBioskopa).FirstOrDefault();
            String stariNaziv = bioskop.Naziv;
            if(Bioskop != null){
                bioskop.Naziv = Bioskop.Naziv;
                bioskop.Adresa = Bioskop.Adresa;
                await Context.SaveChangesAsync();
                return Ok($"Bioskop  sa nazivom: {stariNaziv} je promenjen u {Bioskop.Naziv}");
            }
            else
            {
                return BadRequest("Molimo vas unesite Bioskop");
            }
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        }

      
    }
}
