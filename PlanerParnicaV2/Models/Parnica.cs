using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.Models
{
    public class Parnica
    {
        public Parnica()
        {
            Advokati = new List<KorisnikParnica>();
        }
        public int Id { get; set; }
        public DateTime VremeOdrzavanja { get; set; }
        public Lokacija LokacijaOdrzavanja { get; set; }

        public Kontakt Sudija { get; set; }
        public string TipUstanove { get; set; }

        public string IdentifikatorPostupka { get; set; }
        public string BrojSudnice { get; set; }
        public Kontakt Tuzilac { get; set; }
        public Kontakt Tuzeni { get; set; }
        public string Napomena { get; set; }
        public TipPostupka TipPostupka { get; set; }
        public List<KorisnikParnica> Advokati { get; set; }

    }
}
