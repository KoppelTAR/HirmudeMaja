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
        public string Sisenemisaeg { get; set; }
        public string Väljumisaeg { get; set; }

    }
}
