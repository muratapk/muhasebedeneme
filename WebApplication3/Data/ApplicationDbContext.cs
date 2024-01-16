﻿using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<ili> ilis { get; set; }
        public DbSet<ilcesi> ilcesis { get; set; }
        public DbSet<Okul> Okuls { get; set; }
        public DbSet<Brans>Brans { get; set; }
        public DbSet<Maliyet> Maliyets { get; set; }
        public DbSet<Hesap> Hesaps { get; set; }
        public DbSet<Personel> Personels { get; set; }

    }
}
