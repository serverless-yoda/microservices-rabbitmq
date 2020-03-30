using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Domain.Core.Events
{
    public abstract class Message: IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public string Sender { get; protected set; }
        public Message()
        {
            MessageType = GetType().Name;

        }
    }
}
