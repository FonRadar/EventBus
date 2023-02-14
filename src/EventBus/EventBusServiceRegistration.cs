using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FonRadar.Base.EventBus;

/// <summary>
/// 
/// </summary>
internal sealed class EventBusServiceRegistration : IEventBusServiceRegistration, IDisposable, IAsyncDisposable
{
    private readonly IServiceCollection _serviceCollection;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    public EventBusServiceRegistration(IServiceCollection serviceCollection)
    {
        this._serviceCollection = serviceCollection;
    }

    public IEnumerator<ServiceDescriptor> GetEnumerator()
    {
        return this._serviceCollection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this._serviceCollection).GetEnumerator();
    }

    public void Add(ServiceDescriptor item)
    {
        this._serviceCollection.Add(item);
    }

    public void Clear()
    {
        this._serviceCollection.Clear();
    }

    public bool Contains(ServiceDescriptor item)
    {
        return this._serviceCollection.Contains(item);
    }

    public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
    {
        this._serviceCollection.CopyTo(array, arrayIndex);
    }

    public bool Remove(ServiceDescriptor item)
    {
        return this._serviceCollection.Remove(item);
    }

    public int Count => this._serviceCollection.Count;

    public bool IsReadOnly => this._serviceCollection.IsReadOnly;

    public int IndexOf(ServiceDescriptor item)
    {
        return this._serviceCollection.IndexOf(item);
    }

    public void Insert(int index, ServiceDescriptor item)
    {
        this._serviceCollection.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        this._serviceCollection.RemoveAt(index);
    }

    public ServiceDescriptor this[int index]
    {
        get => this._serviceCollection[index];
        set => this._serviceCollection[index] = value;
    }

    public void Dispose()
    {
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}