using RMQ.Banking.Application.Interfaces;
using RMQ.Banking.Domain.Interfaces;
using RMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repo;

        public AccountService(IAccountRepository repo)
        {
            this.repo = repo;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return repo.GetAccounts();
        }
    }
}
