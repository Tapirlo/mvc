using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentazioni.Models.Database
{
    public class Contesto : DbContext
    {
        public DbSet<Autore> Autori { get; set; }
        public DbSet<Presentazione> Presentazioni { get; set; }
        public DbSet<Registrazione> Registrazioni { get; set; }

        public Contesto(DbContextOptions<Contesto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autore>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
            modelBuilder.Entity<Autore>().Property(x => x.Nome).IsRequired();
            modelBuilder.Entity<Autore>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Autore>().Property(x => x.Telefono).IsRequired();
            modelBuilder.Entity<Autore>().Property(x => x.Skill).IsRequired();
            modelBuilder.Entity<Autore>().HasKey(x => x.Id);

            modelBuilder.Entity<Presentazione>().Property(x => x.Id).IsRequired().UseSqlServerIdentityColumn();
            modelBuilder.Entity<Presentazione>().Property(x => x.Titolo).IsRequired();
            modelBuilder.Entity<Presentazione>().Property(x => x.Inizio).IsRequired();
            modelBuilder.Entity<Presentazione>().Property(x => x.Fine).IsRequired();
            modelBuilder.Entity<Presentazione>().Property(x => x.Livello).IsRequired();
            modelBuilder.Entity<Presentazione>().HasKey(x => x.Id);

            modelBuilder.Entity<Registrazione>().Property(x => x.Autore).IsRequired();
            modelBuilder.Entity<Registrazione>().Property(x => x.Presentazione).IsRequired();
            modelBuilder.Entity<Registrazione>().HasKey(x => new { x.Autore, x.Presentazione });
            modelBuilder.Entity<Registrazione>().HasOne(x => x.AutoreNavigation).WithMany(x => x.Registrazioni).HasForeignKey(x => x.Autore).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Registrazione>().HasOne(x => x.PresentazioneNavigation).WithMany(x => x.Registrazioni).HasForeignKey(x => x.Presentazione).OnDelete(DeleteBehavior.Cascade);






        }
    }
}
