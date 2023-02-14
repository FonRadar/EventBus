using System.Threading;
using System.Threading.Tasks;

namespace FonRadar.Base.EventBus;

/// <summary>
/// Provides basic requirements to event messaging 
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// It publishes an event 
    /// </summary>
    /// <param name="event">instance of the event</param>
    /// <typeparam name="TEventType">Type of the event</typeparam>
    /// <returns>Returns Task for async</returns>
    Task PublishAsync<TEventType>(TEventType @event)
        where TEventType : IEvent
    ;

    /// <summary>
    /// It connects an event handler to an event. 
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TEventType">Type of the event</typeparam>
    /// <typeparam name="TEventHandlerType">Type of event's handler</typeparam>
    /// <returns>Returns Task for async</returns>
    Task SubscribeAsync<TEventType, TEventHandlerType>(CancellationToken cancellationToken)
        where TEventType : IEvent
        where TEventHandlerType : class, IEventHandler<TEventType>
    ;
}