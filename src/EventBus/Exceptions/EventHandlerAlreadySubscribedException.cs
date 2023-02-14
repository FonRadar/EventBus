using System;

namespace FonRadar.Base.EventBus.Exceptions;

/// <summary>
/// 
/// </summary>
public class EventHandlerAlreadySubscribedException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public EventHandlerAlreadySubscribedException(string message) 
        : base(message)
    {
    }
}