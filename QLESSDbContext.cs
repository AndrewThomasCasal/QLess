using Microsoft.EntityFrameworkCore;
using QLess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLess
{
    public class QLESSDbContext : DbContext
    {
        public QLESSDbContext(DbContextOptions<QLESSDbContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardHistory> CardHistories { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<UserCard> UserCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1,
                    Lastname = "istrator",
                    Firstname = "Admin",
                    EmailAddress = "Admin@Test.com",
                    Password = "1234"
                }
                );
            modelBuilder.Entity<CardType>().HasData(
                new CardType
                {
                    Id = 1,
                    CardTypeName = "Regular",
                    RegularRate = 15,
                    BaseDiscount = 0,
                    AdditionalDiscount = 0,
                    AdditionalDiscountMaxUsePerDay = 0,
                    InitialLoad = 100,
                    ValidityPeriod = 5
                },
                new CardType
                {
                    Id = 2,
                    CardTypeName = "Discounted",
                    RegularRate = 10,
                    BaseDiscount = float.Parse("0.2"),
                    AdditionalDiscount = float.Parse("0.03"),
                    AdditionalDiscountMaxUsePerDay = 4,
                    InitialLoad = 500,
                    ValidityPeriod = 3
                }
                );
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType
                {
                    Id = 1,
                    TransactionTypeName = "Load"
                },
                new TransactionType
                {
                    Id = 2,
                    TransactionTypeName = "Use"
                }
                );
        }

    }
}
