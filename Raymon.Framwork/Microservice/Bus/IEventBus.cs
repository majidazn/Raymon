using Raymon.Framwork.Microservice.Commands;
using Raymon.Framwork.Microservice.Events;
using System;
using System.Threading.Tasks;

namespace Raymon.Framwork.Microservice.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        Guid Publish<T>(T @event, Guid? messageId) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
