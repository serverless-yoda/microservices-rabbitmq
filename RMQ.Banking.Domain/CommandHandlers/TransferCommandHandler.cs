using MediatR;
using RMQ.Banking.Domain.Commands;
using RMQ.Banking.Domain.Events;
using RMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RMQ.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus bus;

        public TransferCommandHandler(IEventBus bus)
        {
            this.bus = bus;
        }
        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var transferCreatedEvent = new TransferCreatedEvent(request.From, request.To, request.TransferAmount);
            bus.Publish(transferCreatedEvent);
            return Task.FromResult(true);
        }
    }
}
