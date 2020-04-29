using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanerParnicaV2.DbContext;
using PlanerParnicaV2.Models;
using PlanerParnicaV2.ViewModels;
using PlanerParnicaV2.Services;

namespace PlanerParnicaV2.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly UserManager<Korisnik> userManager;
        private readonly SignInManager<Korisnik> signInManager;
        private readonly AppDbContext context;
        private readonly Services.Services services;

        public KorisnikController(UserManager<Korisnik> userManager,
                                    SignInManager<Korisnik> signInManager,
                                    AppDbContext context,
                                    Services.Services services)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.services = services;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MojeParnice", "Korisnik");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    if(string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt!");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //----------------------------------Parnice---------------------------------
        [HttpGet]
        public IActionResult CreateParnica()
        {
            ParnicaViewModel model = new ParnicaViewModel();
            //model.SviAdvokati = await userManager.GetUsersInRoleAsync("Korisnik");
            model.TipoviPostupaka = context.TipoviPostupaka.ToList();
            model.SveLokacije = context.Lokacije.ToList();
            model.SviKontakti = context.Kontakti.ToList();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateParnica(ParnicaViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            if(ModelState.IsValid)
            {
                services.CreatePanica(model, user);
            }
            return RedirectToAction("MojeParnice", "Korisnik");
        }

        [HttpPost]
        public IActionResult EditParnica(ParnicaViewModel model)
        {
            var parnica = context.Parnice.Include(x => x.LokacijaOdrzavanja)
                            .Include(x => x.TipPostupka)
                            .Include(x => x.Tuzeni)
                            .Include(x => x.Tuzilac)
                            .Include(x => x.Sudija)
                            .FirstOrDefault(x => x.Id == model.Id);
            if (ModelState.IsValid)
            {
                services.EditParnica(parnica, model);
            }

            return RedirectToAction("MojeParnice", "Korisnik");
        }
        [HttpGet]
        public IActionResult EditParnica(int id)
        {
            ParnicaViewModel model = new ParnicaViewModel();
            var parnica = context.Parnice.Include(x => x.LokacijaOdrzavanja)
                                        .Include(x => x.TipPostupka)
                                        .Include(x => x.Tuzeni)
                                        .Include(x => x.Tuzilac)
                                        .Include(x => x.Sudija)
                                        .FirstOrDefault(x => x.Id == id);
            model.TipoviPostupaka = context.TipoviPostupaka.ToList();
            model.SveLokacije = context.Lokacije.ToList();
            model.SviKontakti = context.Kontakti.ToList();
            if (parnica == null)
            {
                ViewBag.ErrorMessage = $"Parnica sa Id: {id} ne postoji!";
                return View();
            }

            model.BrojSudnice = parnica.BrojSudnice;
            model.Id = parnica.Id;
            model.IdentifikatorPostupka = parnica.IdentifikatorPostupka;
            model.LokacijaOdrzvanja = parnica.LokacijaOdrzavanja;
            model.Napomena = parnica.Napomena;
            model.Sudija = parnica.Sudija; 
            model.TipPostupka = parnica.TipPostupka;
            model.Tuzeni = parnica.Tuzeni;
            model.Tuzilac = parnica.Tuzilac;
            model.VremeOdrzavanja = parnica.VremeOdrzavanja;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteParnica(int id)
        {
            var user = await userManager.GetUserAsync(User);
            services.DeletePanica(id, user);
            return RedirectToAction("MojeParnice", "Korisnik");
        }

        [HttpPost]
        public IActionResult DeleteKontakt(int id)
        {
            var parnica = context.Parnice.FirstOrDefault(x => x.Id == id);
            context.Remove(parnica);
            context.SaveChanges();
            return RedirectToAction("ListParnice", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> MojeParnice(MojeParniceViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            return View(services.SearchParnice(model, user));
        }
    }
}