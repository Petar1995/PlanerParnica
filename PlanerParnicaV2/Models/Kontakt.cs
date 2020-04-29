using System;

namespace PlanerParnicaV2.Models
{
    public class Kontakt
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Email { get; set; }
        public TipLica TipLica { get; set; }
        public string Zanimanje { get; set; }
        public Kompanija PripadnostKompaniji { get; set; }
    }
    public enum TipLica
    {
        Pravno,
        Fizicko
    }
}