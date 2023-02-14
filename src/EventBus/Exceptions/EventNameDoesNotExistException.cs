using System;

namespace EventBus.Exceptions;

/// <summary>
/// 
/// </summary>
public class EventNameDoesNotExistException : Exception
{
    /// <summary>
    ///  
    /// </summary>
    /// <param name="message"></param>
    public EventNameDoesNotExistException(string message) 
        : base(message)
    {
    }
}