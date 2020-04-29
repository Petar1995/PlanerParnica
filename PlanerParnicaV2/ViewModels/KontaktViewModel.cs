using PlanerParnicaV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.ViewModels
{
    public class KontaktViewModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Zanimanje { get; set; }
        public bool PripadaKompaniji { get; set; }
        public string KompanijaNaziv { get; set; }
        public string KompanijaAdresa { get; set; }
        public TipLica TipLica { get; set; } 
    }
}
