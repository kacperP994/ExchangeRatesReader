using ExchangeRatesReader.Models;
using ExchangeRatesReader.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRatesReader.Db
{
    public class RatesDbContext : DbContext
    {
        public RatesDbContext(DbContextOptions<RatesDbContext> options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>().Property(x => x.Value).HasPrecision(38, 12);
            modelBuilder.Entity<Currency>().HasIndex(x => x.Code);
            modelBuilder.Entity<Rate>().HasOne(x => x.Currency).WithMany(x => x.Rates);
        }
    }
}
