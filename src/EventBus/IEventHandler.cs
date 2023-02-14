using System.Threading;
using System.Threading.Tasks;

namespace EventBus;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEventType"></typeparam>
public interface IEventHandler<in TEventType>
    where TEventType: IEvent
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="event"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task HandleEvent(TEventType @event, CancellationToken cancellationToken);
}