using Juce.Core.Events.Pipe;

namespace Template.Contents.Services.Events.Service
{
    public class EventsService : IEventsService
    {
        public IEventDispatcherAndReceiver Meta { get; } = new EventDispatcherAndReceiver();
        public IEventDispatcherAndReceiver Stage { get; } = new EventDispatcherAndReceiver();
    }
}