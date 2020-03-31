using RMQ.Domain.Core.Commands;
using RMQ.Domain.Core.Events;
using System.Threading.Tasks;

namespace RMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        //Command is using Message class w/c used IRequest<bool>
        Task SendCommand<T>(T command) where T : Command;

        //Event only have TimeStamp property
        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() 
            where T : Event 
            where TH: IEventHandler<T>;

    }
}
