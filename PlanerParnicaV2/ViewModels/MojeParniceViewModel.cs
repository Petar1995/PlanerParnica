using PlanerParnicaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.ViewModels
{
    public class MojeParniceViewModel
    {
        public List<KorisnikParnica> Parnice { get; set; }
        //-----------------------Search filters----------
        public string SearchIdentifikator { get; set; }
        public string SearchLokacijaOdrzavanja { get; set; }
        public string SearchTuzilac { get; set; }
        public string SearchTuzeni { get; set; }
    }
}
