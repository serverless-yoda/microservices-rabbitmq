using RMQ.Banking.Application.DTO;
using RMQ.Banking.Application.Interfaces;
using RMQ.Banking.Domain.Commands;
using RMQ.Banking.Domain.Interfaces;
using RMQ.Banking.Domain.Models;
using RMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repo;
        private readonly IEventBus bus;

        public AccountService(IAccountRepository repo, IEventBus bus)
        {
            this.repo = repo;
            this.bus = bus;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return repo.GetAccounts();
        }

        public void TransferFunds(AccountTransfer accountTransfer)
        {
            var createTranferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            this.bus.SendCommand(createTranferCommand);
        }
    }
}
