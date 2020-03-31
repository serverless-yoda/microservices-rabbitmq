using RMQ.Banking.Data.Context;
using RMQ.Banking.Domain.Interfaces;
using RMQ.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RMQ.Banking.Data.Repository
{
    public class AccountRepository: IAccountRepository
    {
        private readonly BankingDbContext db;

        public AccountRepository(BankingDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return db.Accounts;
        }
    }
}
