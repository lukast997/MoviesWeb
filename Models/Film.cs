using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Film")]
    public class Film
    {
        [Key]
        public int IdFilma { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }

        [Required]
        public int Cena { get; set; }

        public string Projekcija { get; set; }  
            
        [JsonIgnore]
        public List<Dani> FilmDani {get; set;} 
    }
}