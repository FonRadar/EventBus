using EventBus.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus;

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
    public static IServiceCollection AddEventBus(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ISubscriptionManager, SubscriptionManager>();
        return serviceCollection;
    }
}