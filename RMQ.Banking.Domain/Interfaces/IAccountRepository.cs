using RMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
