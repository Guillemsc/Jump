using Juce.Core.Events.Pipe;

namespace Template.Contents.Services.Events.Service
{
    public interface IEventsService
    {
        IEventDispatcherAndReceiver Meta { get; }
        IEventDispatcherAndReceiver Stage { get; }
    }
}