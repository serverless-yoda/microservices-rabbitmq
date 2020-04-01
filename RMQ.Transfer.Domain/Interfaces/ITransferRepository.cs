using RMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetAllTransferLogs();
    }
}
