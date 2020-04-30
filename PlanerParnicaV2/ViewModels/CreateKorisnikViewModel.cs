using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanerParnicaV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.ViewModels
{
    public class CreateKorisnikViewModel
    {

        [Required]
        [DisplayName("Korisnicko ime")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password doesn't match!")]
        public string ConfirmPassword { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string TipKorisnika { get; set; }
        public bool IsKorisnik { get; set; }
        public bool IsAdmin { get; set; }
    }
}
