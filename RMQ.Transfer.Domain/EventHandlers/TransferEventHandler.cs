using RMQ.Domain.Core.Bus;
using RMQ.Transfer.Domain.Events;
using RMQ.Transfer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository repo;

        public TransferEventHandler(ITransferRepository repo)
        {
            this.repo = repo;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            //TODO: PUT DATABASE CRUD HERE
            return Task.CompletedTask;
        }
    }
}
