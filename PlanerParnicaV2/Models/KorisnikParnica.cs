using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PlanerParnicaV2.Models
{
    public class KorisnikParnica
    {
        public string KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int ParnicaId { get; set; }
        public Parnica Parnica { get; set; }
    }
}
