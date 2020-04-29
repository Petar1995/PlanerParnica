using PlanerParnicaV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.ViewModels
{
    public class ParnicaViewModel
    {
        public ParnicaViewModel()
        {
            TipoviPostupaka = new List<TipPostupka>();
            SviKontakti = new List<Kontakt>();
        }
        public int Id { get; set; }
        public DateTime VremeOdrzavanja { get; set; }
        public List<Lokacija> SveLokacije { get; set; }
        public Lokacija LokacijaOdrzvanja { get; set; }
        public Kontakt Sudija { get; set; }
        public TipUstanove TipUstanove { get; set; }
        public string IdentifikatorPostupka { get; set; }
        public string BrojSudnice { get; set; }
        public Kontakt Tuzilac { get; set; }
        public Kontakt Tuzeni { get; set; }
        public string Napomena { get; set; }
        public TipPostupka TipPostupka { get; set; }
        public List<TipPostupka> TipoviPostupaka { get; set; }
        public List<Kontakt> SviKontakti { get; set; }
    }
    public enum TipUstanove
    {
        OpstiSud,
        VisiSud,
        ApelacioniSud,
        VrhovniKasacioniSud,
        PrivredniSud,
        PrivredniApelacioniSud,
        PrekrsajniSud,
        PrekrsajniApelacioniSud,
        UpravniSud
    };
}
