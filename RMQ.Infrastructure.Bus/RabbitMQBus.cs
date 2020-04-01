using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RMQ.Domain.Core.Bus;
using RMQ.Domain.Core.Commands;
using RMQ.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMQ.Infrastructure.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;

        public RabbitMQBus(IMediator mediator, IServiceScopeFactory scope)
        {
            _mediator = mediator;
            _scopeFactory = scope;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection()) 
            using(var channel = connection.CreateModel())
            {
                var eventname = @event.GetType().Name;

                channel.QueueDeclare(eventname, false, false, false, null);
                var message = JsonConvert.SerializeObject(@event);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventname, null, body);
            };

        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventname = typeof(T).Name;
            var handlertype = typeof(TH);

            if(!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if(!_handlers.ContainsKey(eventname))
            {
                _handlers.Add(eventname, new List<Type>());
            }

            //validations
            if(_handlers[eventname].Any(a => a.GetType() == handlertype))
            {
                throw new ArgumentException($"Handler type {handlertype.Name} is registered for {eventname}");
            }

            _handlers[eventname].Add(handlertype);

            StartBasicConsume<T>();
        }

        void StartBasicConsume<T>() where T: Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };

            using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
            {
                var eventname = typeof(T).Name;
                channel.QueueDeclare(eventname, false, false, false, null);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;

                channel.BasicConsume(eventname, true, consumer);
            }
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventname = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body);

            try
            {
                await ProcessEvent(eventname, message).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
        }

        private async Task ProcessEvent(string eventname, string message)
        {
           if(_handlers.ContainsKey(eventname))
            {
                var subscriptions = _handlers[eventname];
                
                foreach(var subscription in subscriptions)
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);//Activator.CreateInstance(subscription);
                        if (handler == null) continue;


                        var eventtype = _eventTypes.SingleOrDefault(t => t.Name == eventname);
                        var @event = JsonConvert.DeserializeObject(message, eventtype);

                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventtype);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                    
                }
            }
        }
    }
}
