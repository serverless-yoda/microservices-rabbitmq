using Microsoft.EntityFrameworkCore;
using RMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Banking.Data.Context
{
    public class BankingDbContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public BankingDbContext(DbContextOptions<BankingDbContext> option) : base(option)
        {

        }
    }
}
