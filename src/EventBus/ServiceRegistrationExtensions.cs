using FonRadar.Base.EventBus.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FonRadar.Base.EventBus;

/// <summary>
/// 
/// </summary>
public static class ServiceRegistrationExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IEventBusServiceRegistration AddEventBus(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ISubscriptionManager, SubscriptionManager>();
        return new EventBusServiceRegistration(serviceCollection);
    }
}