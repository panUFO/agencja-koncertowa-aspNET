using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using agencja.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace agencja.DAL
{
    public class AgencjaContext : DbContext
    {
        public AgencjaContext() : base("AgencjaContext")
        {
        }

        public DbSet<Klub> Kluby { get; set; }
        public DbSet<Koncert> Koncerty { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}