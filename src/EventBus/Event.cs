using System;
using System.Text;

namespace FonRadar.Base.EventBus;

/// <summary>
/// Concrete event base
/// </summary>
public abstract record Event : IEvent
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Create an event with default values
    /// </summary>
    protected Event()
    {
        byte[] bytes = Encoding.UTF8.GetBytes(this.Date.Ticks.ToString().Substring(0, 16));
        this.Id = new Guid(bytes);
        this.Date = DateTime.Now;
    }

    /// <summary>
    /// Create an event with default values
    /// </summary>
    /// <param name="id"></param>
    protected Event(Guid id)
    {
        this.Id = id;
        this.Date = DateTime.Now;
        byte[] bytes = Encoding.UTF8.GetBytes(this.Date.Ticks.ToString().Substring(0, 16));
    }

    /// <summary>
    /// Create an event with custom id and custom date
    /// </summary>
    /// <param name="id"></param>
    /// <param name="date"></param>
    protected Event(Guid id, DateTime date)
    {
        this.Id = id;
        this.Date = date;
    }
}