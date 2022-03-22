using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Bioskop")]
    public class Bioskop
    {
        [Key]
        public int IdBioskopa { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Naziv { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Adresa { get; set; }

        public List<Dani> DaniBioskop {get; set;}
        
    }
}