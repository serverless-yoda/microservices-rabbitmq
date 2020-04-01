using RMQ.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetAllTransferLogs();
    }
}
