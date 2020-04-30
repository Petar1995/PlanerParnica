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
        private readonly RoleManager<IdentityRole> roleManager;

        public KorisnikController(UserManager<Korisnik> userManager,
                                    SignInManager<Korisnik> signInManager,
                                    AppDbContext context,
                                    Services.Services services,
                                    RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.services = services;
            this.roleManager = roleManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Korisnik"))
                    return RedirectToAction("MojeParnice", "Korisnik");
                else
                    return RedirectToAction("ListKorisnici", "Admin");
            }
            var admins = await userManager.GetUsersInRoleAsync("Administrator");
            if (admins.Count == 0)
                return RedirectToAction("FirstAdmin", "Korisnik");
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
                    return RedirectToAction("MojeParnice", "Korisnik");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt!");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Korisnik");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FirstAdmin()
        {
            var admini = await userManager.GetUsersInRoleAsync("Administrator");
            if (admini.Count > 0)
                RedirectToAction("Login", "Korisnik");
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> FirstAdmin(CreateKorisnikViewModel model)
        {
            var roleResult = await roleManager.RoleExistsAsync("Administrator");
            if(!roleResult)
            {
                IdentityRole AdminRole = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(AdminRole);
            }
            roleResult = await roleManager.RoleExistsAsync("Korisnik");
            if (!roleResult)
            {
                IdentityRole KorisnikRole = new IdentityRole
                {
                    Name = "Korisnik"
                };
                await roleManager.CreateAsync(KorisnikRole);
            }
            var admini = await userManager.GetUsersInRoleAsync("Administrator");
            if (admini.Count > 0)
                RedirectToAction("Login", "Korisnik");
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
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return RedirectToAction("Login","Korisnik");
        }
        //----------------------------------Parnice---------------------------------
        [HttpGet]
        public IActionResult CreateParnica()
        {
            ParnicaViewModel model = new ParnicaViewModel();
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
            bool result = await userManager.IsInRoleAsync(user, "Korisnik");
            if (!result)
                return RedirectToAction("ListParnice", "Admin");
            return View(services.SearchParnice(model, user));
        }
    }
}