using Microsoft.Extensions.DependencyInjection;
using RMQ.Domain.Core.Bus;
using RMQ.Infrastructure.Bus;

namespace RMQ.Infrastructure.IoC
{
    public class DIContainer
    {
        public static void RegisterServices(IServiceCollection services) {
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
