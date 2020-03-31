using RMQ.Banking.Domain.Models;
using System.Collections.Generic;

namespace RMQ.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
