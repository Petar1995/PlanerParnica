using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.ViewModels
{
    public class EditKorisnikViewModel
    {
        [DisplayName("Korisnicko ime")]
        public string Username { get; set; }
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool IsKorisnik { get; set; }
        public bool IsAdmin { get; set; }
    }
}
