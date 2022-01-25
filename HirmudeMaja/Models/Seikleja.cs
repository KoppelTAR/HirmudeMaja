using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HirmudeMaja.Models
{
    public class Seikleja
    {
        public int Id { get; set; }
        [StringLength(64)]
        [Required]
        public string Eesnimi { get; set; }
        public DateTime? Sisenemisaeg { get; set; }
        public DateTime? Väljumisaeg { get; set; }

    }
}
