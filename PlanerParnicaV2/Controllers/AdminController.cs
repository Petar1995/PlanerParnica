using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlanerParnicaV2.DbContext;
using PlanerParnicaV2.Models;
using PlanerParnicaV2.ViewModels;

namespace PlanerParnicaV2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Korisnik> userManager;
        private readonly SignInManager<Korisnik> signInManager;
        private readonly AppDbContext context;
        private readonly Services.Services services;

        public AdminController(RoleManager<IdentityRole> roleManager,
                                UserManager<Korisnik> userManager,
                                SignInManager<Korisnik> signInManager,
                                AppDbContext context,
                                Services.Services services)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.services = services;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        //[AcceptVerbs("Get", "Post")]
        //public async Task<IActionResult> KorisnikExists(CreateViewModel korisnik)
        //{
        //    var user = await userManager.FindByNameAsync(korisnik.Username);
        //    if (user == null)
        //    {
        //        return Json(true);
        //    }
        //    else
        //    {
        //        return Json($"Korisnik {korisnik.Username} vec postoji!");
        //    }
        //}

        [HttpGet]
        public IActionResult CreateKorisnik()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateKorisnik(CreateKorisnikViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Korisnik
                {
                    UserName = model.Username,
                    Ime = model.Ime,
                    Prezime = model.Prezime
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.IsKorisnik)
                    { 
                        await userManager.AddToRoleAsync(user, "Korisnik"); 
                    }
                    if(model.IsAdmin)
                    {
                        await userManager.AddToRoleAsync(user, "Administrator");
                    }
                    return RedirectToAction("ListKorisnici", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListKorisnici()
        {
            //ListKorisniciViewModel list = new ListKorisniciViewModel();
            var korisnici = await userManager.GetUsersInRoleAsync("Korisnik");
            return View(korisnici);
        }

        [HttpGet]
        public async Task<IActionResult> ListAdmin()
        {
            //ListKorisniciViewModel list = new ListKorisniciViewModel();
            var korisnici = await userManager.GetUsersInRoleAsync("Administrator");
            return View(korisnici);
        }

        [HttpGet]
        public async Task<IActionResult> EditKorisnik(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Korisnik sa korisnicko ime: {userName} ne postoji!";
                return View();
            }
            var model = new EditKorisnikViewModel
            {
                Id = user.Id,
                Ime = user.Ime,
                Prezime = user.Prezime,
            };
            if(await userManager.IsInRoleAsync(user, "Korisnik"))
            {
                model.IsKorisnik = true;
            }
            if (await userManager.IsInRoleAsync(user, "Administrator"))
            {
                model.IsAdmin = true;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditKorisnik(EditKorisnikViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Korisnik sa korisnicko ime: {user.UserName} ne postoji!";
                return View();
            }
            else
            {
                user.Ime = model.Ime;
                user.Prezime = model.Prezime;
                if (model.IsKorisnik)
                {
                    if (!await userManager.IsInRoleAsync(user, "Korisnik"))
                    {
                        await userManager.AddToRoleAsync(user, "Korisnik");
                    }
                }
                else
                {
                    if(await userManager.IsInRoleAsync(user,"Korisnik"))
                    {
                        await userManager.RemoveFromRoleAsync(user, "Korisnik");
                    }
                }
                if (model.IsAdmin)
                {
                    if (!await userManager.IsInRoleAsync(user, "Administrator"))
                    {
                        await userManager.AddToRoleAsync(user, "Administrator");
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, "Administrator"))
                    {
                        await userManager.RemoveFromRoleAsync(user, "Administrator");
                    }
                }
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListKorisnici", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteKorisnik(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Korisnik sa Id: {id} ne postoji!";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListKorisnici", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return RedirectToAction("ListKorisnici", "Admin");
        }

        [HttpGet]
        public IActionResult ListParnice()
        {
            var parnice = context.Parnice
                                .Include(x => x.Tuzeni)
                                .Include(x => x.Tuzilac)
                                .Include(x => x.Sudija)
                                .Include(x => x.LokacijaOdrzavanja)
                                .Include(x => x.TipPostupka)
                                .ToList();
            return View(parnice);
        }
        //------------------------------------------Lokacija--------------------------------------------------
        [HttpGet]
        public IActionResult ListLokacije()
        {
            var lokacije = context.Lokacije;
            return View(lokacije);
        }

        [HttpGet]
        public IActionResult CreateLokacija()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLokacija(LokacijaViewModel model)
        {
            var lokacija = new Lokacija
            {
                Naslov = model.Naslov
            };
            context.Add(lokacija);
            context.SaveChanges();

            return RedirectToAction("ListLokacije", "Admin");
        }
        [HttpPost]
        public IActionResult DeleteLokacija(int id)
        {
            var lokacija = context.Lokacije.Find(id);
            if (lokacija == null)
            {
                ViewBag.ErrorMessage = $"Lokacija sa Id: {id} ne postoji!";
                return View();
            }
            context.Remove(lokacija);
            context.SaveChanges();
            return RedirectToAction("ListLokacije", "Admin");
        }
        [HttpGet]
        public IActionResult EditLokacija(int id)
        {
            var lokacija = context.Lokacije.Find(id);
            if (lokacija == null)
            {
                ViewBag.ErrorMessage = $"Lokacija sa Id: {id} ne postoji!";
                return View();
            }

            var model = new LokacijaViewModel
            {
                Id = lokacija.Id,
                Naslov = lokacija.Naslov
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditLokacija(LokacijaViewModel model)
        {
            var lokacija = context.Lokacije.Find(model.Id);
            if (lokacija == null)
            {
                ViewBag.ErrorMessage = $"Lokacija sa Id: {model.Id} ne postoji!";
                return View();
            }
            lokacija.Naslov = model.Naslov;
            context.Update(lokacija);
            context.SaveChanges();
            return RedirectToAction("ListLokacije", "Admin");
        }
        //----------------------------------TipPostupka-------------------------------------------
        [HttpGet]
        public IActionResult ListTipoviPostupaka()
        {
            var tipovi = context.TipoviPostupaka;
            return View(tipovi);
        }

        [HttpGet]
        public IActionResult CreateTipPostupka()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTipPostupka(TipPostupkaViewModel model)
        {
            var tipPostupka = new TipPostupka
            {
                Naslov = model.Naslov
            };
            context.Add(tipPostupka);
            context.SaveChanges();

            return RedirectToAction("ListTipoviPostupaka", "Admin");
        }
        [HttpPost]
        public IActionResult DeleteTipPostupka(int id)
        {
            var tipPostupka = context.TipoviPostupaka.Find(id);
            context.Remove(tipPostupka);
            context.SaveChanges();
            return RedirectToAction("ListTipoviPostupaka", "Admin");
        }
        [HttpGet]
        public IActionResult EditTipPostupka(int id)
        {
            var tipPostupka = context.TipoviPostupaka.Find(id);
            if (tipPostupka == null)
            {
                ViewBag.ErrorMessage = $"Tip postupka sa Id: {id} ne postoji!";
                return View();
            }

            var model = new TipPostupkaViewModel
            {
                Id = tipPostupka.Id,
                Naslov = tipPostupka.Naslov
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditTipPostupka(LokacijaViewModel model)
        {
            var tipPostupka = context.TipoviPostupaka.Find(model.Id);
            if (tipPostupka == null)
            {
                ViewBag.ErrorMessage = $"Tip postupka sa Id: {model.Id} ne postoji!";
                return View();
            }
            tipPostupka.Naslov = model.Naslov;
            context.Update(tipPostupka);
            context.SaveChanges();
            return RedirectToAction("ListTipoviPostupaka", "Admin");
        }
        //--------------------------------Kontakt i Kompanija----------------------------------
        [HttpGet]
        public IActionResult ListKontakti()
        {
            var kontakti = context.Kontakti.Include(x => x.PripadnostKompaniji);
            return View(kontakti);
        }

        [HttpGet]
        public IActionResult CreateKontakt()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateKontakt(KontaktViewModel model)
        {
            services.CreateKontakt(model);
            return RedirectToAction("ListKontakti", "Admin");
        }
        [HttpPost]
        public IActionResult DeleteKontakt(int id)
        {
            services.DeleteKontakt(id);
            return RedirectToAction("ListKontakti", "Admin");
        }
        [HttpGet]
        public IActionResult EditKontakt(int id)
        {
            var kontakt = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Id == id);
            if (kontakt == null)
            {
                ViewBag.ErrorMessage = $"Kontakt sa Id: {id} ne postoji!";
                return View();
            }

            var model = new KontaktViewModel
            {
                Id = kontakt.Id,
                Ime = kontakt.Ime,
                Email = kontakt.Email,
                Telefon1 = kontakt.Telefon1,
                Telefon2 = kontakt.Telefon2,
                Zanimanje = kontakt.Zanimanje
            };
            if (kontakt.PripadnostKompaniji != null)
            {
                model.PripadaKompaniji = true;
                model.KompanijaAdresa = kontakt.PripadnostKompaniji.Adresa;
                model.KompanijaNaziv = kontakt.PripadnostKompaniji.Naziv;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditKontakt(KontaktViewModel model)
        {
            var kontakt = context.Kontakti.Include(x => x.PripadnostKompaniji).FirstOrDefault(x => x.Id == model.Id);
            if (kontakt == null)
            {
                ViewBag.ErrorMessage = $"Kontakt sa Id: {model.Id} ne postoji!";
                return View();
            }
            services.EditKontakt(kontakt, model);
            return RedirectToAction("ListKontakti", "Admin");
        }

        [HttpGet]
        public IActionResult ListKompanije()
        {
            var kompanije = context.Kompanije;
            return View(kompanije);
        }
        [HttpPost]
        public IActionResult DeleteKompanija(int id)
        {
            var kompanija = context.Kompanije.Find(id);
            context.Remove(kompanija);
            context.SaveChanges();
            return RedirectToAction("ListKompanije", "Admin");
        }
        [HttpGet]
        public IActionResult EditKompanija(int id)
        {
            var kompanija = context.Kompanije.Find(id);
            if (kompanija == null)
            {
                ViewBag.ErrorMessage = $"Kompanija sa Id: {id} ne postoji!";
                return View();
            }

            var model = new KompanijaViewModel
            {
                Id = kompanija.Id,
                Naziv = kompanija.Naziv,
                Adresa = kompanija.Adresa
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult EditKompanija(KompanijaViewModel model)
        {
            var kompanija = context.Kompanije.Find(model.Id);
            if (kompanija == null)
            {
                ViewBag.ErrorMessage = $"Kompanija sa Id: {model.Id} ne postoji!";
                return View();
            }
            services.UptadeKompanija(kompanija, model);
            return RedirectToAction("ListKompanije", "Admin");
        }
    }
}