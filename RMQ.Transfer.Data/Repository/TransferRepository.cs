using RMQ.Transfer.Data.Context;
using RMQ.Transfer.Domain.Interfaces;
using RMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext db;

        public TransferRepository(TransferDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<TransferLog> GetAllTransferLogs()
        {
            return this.db.TransferLogs;
        }
    }
}
