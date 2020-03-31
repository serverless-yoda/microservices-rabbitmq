using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Banking.Domain.Commands
{
    public class CreateTransferCommand : TransferCommand
    {
        public CreateTransferCommand(int from, int to, decimal transferAmount)
        {
            From = from;
            To = to;
            TransferAmount = transferAmount;
        }
    }
}
