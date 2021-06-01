using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models;
using UBAInterviewPrepAPI.Domain.Models.Auth;
using UBAInterviewPrepAPI.Domain.Models.InvestmentModels;

namespace UBAInterviewPrepAPI.DAL.Data.Context
{
    public class MyDataContext : IdentityDbContext<User, Role, Guid>
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<MonthlyInvestmentQuote> MonthlyInvestmentQuotes { get; set; }
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasMany<Investment>().WithOne().HasForeignKey(prop => prop.UserId);
            builder.Entity<Portfolio>().HasMany<Investment>().WithOne().HasForeignKey(x => x.PortfolioId);
            //we also want an Administrator User to be able to create a Portfolio so 
            // Let's create a relationship between User and Portfolio
            builder.Entity<User>().HasMany<Portfolio>().WithOne().HasForeignKey(x => x.CreatorId);
            builder.Entity<Investment>().HasMany<MonthlyInvestmentQuote>().WithOne().HasForeignKey(x => x.InvestmentId);
        }
    }
}
