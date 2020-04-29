using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanerParnicaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanerParnicaV2.DbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public DbSet<Kompanija> Kompanije { get; set; }
        public DbSet<Kontakt> Kontakti { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Lokacija> Lokacije { get; set; }
        public DbSet<Parnica> Parnice { get; set; }
        public DbSet<TipPostupka> TipoviPostupaka { get; set; }
        

        public DbSet<KorisnikParnica> KorisnikParnica { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<KorisnikParnica>()
                .HasKey(x => new { x.KorisnikId, x.ParnicaId });
        }

    }
    
}
