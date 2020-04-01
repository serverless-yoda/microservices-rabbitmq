using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RMQ.Banking.Application.Interfaces;
using RMQ.Banking.Application.Services;
using RMQ.Banking.Data.Context;
using RMQ.Banking.Data.Repository;
using RMQ.Banking.Domain.CommandHandlers;
using RMQ.Banking.Domain.Commands;
using RMQ.Banking.Domain.Interfaces;
using RMQ.Domain.Core.Bus;
using RMQ.Infrastructure.Bus;
using RMQ.Transfer.Application.Interfaces;
using RMQ.Transfer.Application.Services;
using RMQ.Transfer.Data.Context;
using RMQ.Transfer.Data.Repository;
using RMQ.Transfer.Domain.Interfaces;

namespace RMQ.Infrastructure.IoC
{
    public class DIContainer
    {
        public static void RegisterServices(IServiceCollection services) {

            services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddDbContext<BankingDbContext>();
            services.AddDbContext<TransferDbContext>();
        }
    }
}
