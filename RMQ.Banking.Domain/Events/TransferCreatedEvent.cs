using RMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Banking.Domain.Events
{
    public class TransferCreatedEvent: Event
    {
        public int From { get; private set; }
        public int To { get; private set; }
        public decimal TransferAmount { get; private set; }

        public TransferCreatedEvent(int from, int to, decimal transferAmount)
        {
            From = from;
            To = to;
            TransferAmount = transferAmount;
        }
    }
}
