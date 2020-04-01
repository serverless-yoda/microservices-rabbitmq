using Microsoft.EntityFrameworkCore;
using RMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Transfer.Data.Context
{
    public class TransferDbContext: DbContext
    {
        public DbSet<TransferLog> TransferLogs { get; set; }
        public TransferDbContext(DbContextOptions<TransferDbContext> option) : base(option)
        {

        }
    }
}
