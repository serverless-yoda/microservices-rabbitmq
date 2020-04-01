using RMQ.Domain.Core.Bus;
using RMQ.Transfer.Application.Interfaces;
using RMQ.Transfer.Domain.Interfaces;
using RMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository repo;
        private readonly IEventBus bus;

        public TransferService(ITransferRepository repo, IEventBus bus)
        {
            this.repo = repo;
            this.bus = bus;
        }
        public IEnumerable<TransferLog> GetAllTransferLogs()
        {
            return this.repo.GetAllTransferLogs();
        }
    }
}
