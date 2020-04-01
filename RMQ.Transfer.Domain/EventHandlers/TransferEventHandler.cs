using RMQ.Domain.Core.Bus;
using RMQ.Transfer.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        public TransferEventHandler()
        {

        }
        public Task Handle(TransferCreatedEvent @event)
        {

            return Task.CompletedTask;
        }
    }
}
