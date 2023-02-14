using System;
using System.Collections.Generic;
using System.Linq;
using EventBus.Exceptions;
using Microsoft.Extensions.Logging;

namespace EventBus.Internal;

/// <summary>
/// 
/// </summary>
internal class SubscriptionManager : ISubscriptionManager
{
    private readonly ILogger<SubscriptionManager> _logger;
    private readonly SortedDictionary<string, List<Type>> _eventHandlerStorage;

    /// <summary>
    /// It returns the event handler storage has any event.
    /// </summary>
    public bool IsEventBusEmpty
    {
        get { return this._eventHandlerStorage.Any(); }
    }

    public SubscriptionManager(
        ILogger<SubscriptionManager> logger
    ) {
        this._logger = logger;
        this._eventHandlerStorage = new SortedDictionary<string, List<Type>>();
    }

    /// <summary>
    /// Subscribe an event handler to an event
    /// </summary>
    /// <typeparam name="TEventType">Type of event</typeparam>
    /// <typeparam name="TEventHandlerType">Type of event handler</typeparam>
    /// <exception cref="EventHandlerAlreadySubscribedException">
    /// It throws this exception when the event handler has been subscribed to the event before
    /// </exception>
    public void Subscribe<TEventType, TEventHandlerType>()
        where TEventType : IEvent
        where TEventHandlerType : IEventHandler<TEventType>
    {
        string eventName = this.GetEventName<TEventType>();
        if (!this.HasEvent<TEventType>())
        {
            this._eventHandlerStorage.Add(eventName, new List<Type>());
        }
        else
        {
            if (this.HasSameEventHandler<TEventType, TEventHandlerType>())
            {
                throw new EventHandlerAlreadySubscribedException($"Event: {eventName} -> Handler: {typeof(TEventHandlerType).FullName}");
            }
        }

        this._eventHandlerStorage[eventName].Add(typeof(TEventHandlerType));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <typeparam name="TEventHandlerType"></typeparam>
    public void Unsubscribe<TEventType, TEventHandlerType>()
        where TEventType : IEvent
        where TEventHandlerType : IEventHandler<TEventType>
    {
        string eventName = this.GetEventName<TEventType>();
        if (this.HasEvent<TEventType>() && this.HasSameEventHandler<TEventType, TEventHandlerType>())
        {
            this._eventHandlerStorage[eventName].Remove(typeof(TEventHandlerType));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <returns></returns>
    public bool HasEvent<TEventType>()
        where TEventType : IEvent
    {
        string eventName = this.GetEventName<TEventType>();
        bool hasEvent = this._eventHandlerStorage.ContainsKey(eventName);
        return hasEvent;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        this._eventHandlerStorage.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <typeparam name="TEventHandlerType"></typeparam>
    /// <returns></returns>
    private bool HasSameEventHandler<TEventType, TEventHandlerType>()
        where TEventType : IEvent
        where TEventHandlerType : IEventHandler<TEventType>
    {
        string eventName = this.GetEventName<TEventType>();
        bool hasSameHandler = this._eventHandlerStorage[eventName].Contains(typeof(TEventHandlerType));
        return hasSameHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventType"></typeparam>
    /// <returns></returns>
    /// <exception cref="EventNameDoesNotExistException"></exception>
    private string GetEventName<TEventType>()
        where TEventType : IEvent
    {
        string? eventName = typeof(TEventType).FullName;
        if (eventName == null)
        {
            throw new EventNameDoesNotExistException($"The event '{typeof(TEventType)}' does not have a FullName");
        }

        return eventName;
    }

}