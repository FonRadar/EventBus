namespace EventBus.Internal;

/// <summary>
/// 
/// </summary>
internal interface ISubscriptionManager
{
    /// <summary>
    /// It returns 
    /// </summary>
    bool IsEventBusEmpty { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <typeparam name="TEventHandlerType"></typeparam>
    void Subscribe<TEventType, TEventHandlerType>()
        where TEventType : IEvent
        where TEventHandlerType : IEventHandler<TEventType>
    ;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <typeparam name="TEventHandlerType"></typeparam>
    void Unsubscribe<TEventType, TEventHandlerType>()
        where TEventType : IEvent
        where TEventHandlerType : IEventHandler<TEventType>
    ;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <returns></returns>
    bool HasEvent<TEventType>()
        where TEventType : IEvent
    ;

    /// <summary>
    /// 
    /// </summary>
    void Clear();
}