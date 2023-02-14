using System.Threading;
using System.Threading.Tasks;

namespace EventBus;

/// <summary>
/// 
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="event"></param>
    /// <typeparam name="TEventType"></typeparam>
    /// <returns></returns>
    Task PublishAsync<TEventType>(TEventType @event)
        where TEventType : IEvent
    ;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TEventType"></typeparam>
    /// <typeparam name="TEventHandlerType"></typeparam>
    /// <returns></returns>
    Task SubscribeAsync<TEventType, TEventHandlerType>(CancellationToken cancellationToken)
        where TEventType : IEvent
        where TEventHandlerType : IEventHandler<TEventType>
    ;
}