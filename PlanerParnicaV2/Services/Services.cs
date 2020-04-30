using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanerParnicaV2.DbContext;
using PlanerParnicaV2.Models;
using PlanerParnicaV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.Services
{
    public class Services
    {
        private readonly AppDbContext context;
        private readonly UserManager<Korisnik> userManager;

        public Services(AppDbContext context,
                        UserManager<Korisnik> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public void DeletePanica(int id, Korisnik user)
        {
            var parnica = context.Parnice.FirstOrDefault(x => x.Id == id);
            KorisnikParnica advokat = new KorisnikParnica
            {
                Korisnik = user,
                Parnica = parnica
            };
            context.KorisnikParnica.Remove(advokat);
            parnica = context.Parnice.Include(x => x.Advokati).FirstOrDefault(x => x.Id == id);
            if (parnica.Advokati.Count - 1 == 0)
                context.Remove(parnica);
            context.SaveChanges();
        }
        public void CreatePanica(ParnicaViewModel model, Korisnik user)
        {
            if (context.Parnice.Any(x => x.IdentifikatorPostupka == model.IdentifikatorPostupka))
            {
                KorisnikParnica item = new KorisnikParnica
                {
                    Korisnik = user,
                    Parnica = context.Parnice.Single(x => x.IdentifikatorPostupka == model.IdentifikatorPostupka)
                };
                context.KorisnikParnica.Add(item);
            }
            else
            {
                var parnica = new Parnica
                {
                    IdentifikatorPostupka = model.IdentifikatorPostupka,
                    VremeOdrzavanja = model.VremeOdrzavanja,
                    BrojSudnice = model.BrojSudnice,
                    Napomena = model.Napomena,
                    TipUstanove = model.TipUstanove.ToString()
                };
                parnica.TipPostupka = context.TipoviPostupaka.FirstOrDefault(x => x.Naslov == model.TipPostupka.Naslov);
                parnica.LokacijaOdrzavanja = context.Lokacije.FirstOrDefault(x => x.Naslov == model.LokacijaOdrzvanja.Naslov);
                parnica.Tuzeni = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Ime == model.Tuzeni.Ime);
                parnica.Tuzilac = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Ime == model.Tuzilac.Ime);
                parnica.Sudija = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Ime == model.Sudija.Ime);

                KorisnikParnica item = new KorisnikParnica
                {
                    Korisnik = user,
                    Parnica = parnica
                };
                context.KorisnikParnica.Add(item);

                context.Add(parnica);
            }
            context.SaveChanges();
        }
        public void EditParnica(Parnica parnica, ParnicaViewModel model)
        {
            parnica.IdentifikatorPostupka = model.IdentifikatorPostupka;
            parnica.VremeOdrzavanja = model.VremeOdrzavanja;
            parnica.BrojSudnice = model.BrojSudnice;
            parnica.Napomena = model.Napomena;
            parnica.TipUstanove = model.TipUstanove.ToString();
            parnica.TipPostupka = context.TipoviPostupaka.FirstOrDefault(x => x.Naslov == model.TipPostupka.Naslov);
            parnica.LokacijaOdrzavanja = context.Lokacije.FirstOrDefault(x => x.Naslov == model.LokacijaOdrzvanja.Naslov);
            parnica.Tuzeni = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Ime == model.Tuzeni.Ime);
            parnica.Tuzilac = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Ime == model.Tuzilac.Ime);
            parnica.Sudija = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Ime == model.Sudija.Ime);

            context.Update(parnica);
            context.SaveChanges();
        }
        public void UpdateKompanija(Kompanija kompanija, KompanijaViewModel model)
        {
            kompanija.Naziv = model.Naziv;
            kompanija.Adresa = model.Adresa;
            context.Update(kompanija);
            context.SaveChanges();
        }
        public void EditKontakt(Kontakt kontakt, KontaktViewModel model)
        {
            kontakt.Ime = model.Ime;
            kontakt.Id = model.Id;
            kontakt.Ime = model.Ime;
            kontakt.Email = model.Email;
            kontakt.Telefon1 = model.Telefon1;
            kontakt.Telefon2 = model.Telefon2;
            kontakt.Zanimanje = model.Zanimanje;
            if (model.PripadaKompaniji == true)
            {

                if (kontakt.PripadnostKompaniji != null)
                {
                    kontakt.PripadnostKompaniji.Naziv = model.KompanijaNaziv;
                    kontakt.PripadnostKompaniji.Adresa = model.KompanijaAdresa;
                    context.Update(kontakt.PripadnostKompaniji);
                }
                else
                {
                    Kompanija kompanija = new Kompanija();
                    kompanija.Naziv = model.KompanijaNaziv;
                    kompanija.Adresa = model.KompanijaAdresa;
                    kontakt.PripadnostKompaniji = kompanija;
                    context.Add(kompanija);
                }
            }
            context.Update(kontakt);
            context.SaveChanges();
        }
        public void DeleteKontakt(int id)
        {
            var kontakt = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Id == id);
            var kompanija = context.Kompanije.Find(kontakt.PripadnostKompaniji.Id);
            context.Remove(kontakt);
            context.Remove(kompanija);
            context.SaveChanges();
        }
        public void CreateKontakt(KontaktViewModel model)
        {
            var kontakt = new Kontakt
            {
                Email = model.Email,
                Ime = model.Ime,
                Telefon1 = model.Telefon1,
                Zanimanje = model.Zanimanje,
                Telefon2 = model.Telefon2,
                TipLica = model.TipLica
            };
            if (model.PripadaKompaniji == true)
            {
                Kompanija kompanija = new Kompanija
                {
                    Naziv = model.KompanijaNaziv,
                    Adresa = model.KompanijaAdresa
                };
                kontakt.PripadnostKompaniji = kompanija;
                context.Add(kompanija);
            }
            context.Add(kontakt);
            context.SaveChanges();
        }


        public MojeParniceViewModel SearchParnice(MojeParniceViewModel searchModel, Korisnik user)
        {
            List<KorisnikParnica> parnice = context.KorisnikParnica
                                            .Include(x => x.Parnica)
                                            .Where(x => x.KorisnikId == user.Id)
                                            .Include(x => x.Parnica.Tuzeni)
                                            .Include(x => x.Parnica.Tuzilac)
                                            .Include(x => x.Parnica.Sudija)
                                            .Include(x => x.Parnica.LokacijaOdrzavanja)
                                            .Include(x => x.Parnica.TipPostupka)
                                            .ToList();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.SearchIdentifikator))
                    parnice = parnice.Where(x => x.Parnica.IdentifikatorPostupka.Contains(searchModel.SearchIdentifikator)).ToList();
                if (!string.IsNullOrEmpty(searchModel.SearchLokacijaOdrzavanja))
                    parnice = parnice.Where(x => x.Parnica.LokacijaOdrzavanja.Naslov.Contains(searchModel.SearchLokacijaOdrzavanja)).ToList();
                if (!string.IsNullOrEmpty(searchModel.SearchTuzeni))
                    parnice = parnice.Where(x => x.Parnica.Tuzeni.Ime.Contains(searchModel.SearchTuzeni)).ToList();
                if (!string.IsNullOrEmpty(searchModel.SearchTuzilac))
                    parnice = parnice.Where(x => x.Parnica.Tuzilac.Ime.Contains(searchModel.SearchTuzilac)).ToList();
            }
            MojeParniceViewModel model = new MojeParniceViewModel
            {
                Parnice = parnice
            };

            return model;
        }
    }
}
