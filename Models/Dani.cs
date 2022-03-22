using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Dani")]
    public class Dani
    {
        [Key]
        public int IdDana { get; set; }

        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }
        public List<Film> FilmoviDani {get; set;}        
        [JsonIgnore]
        public List<Bioskop> DaniBioskop {get; set;}
    }
}