using Microsoft.Extensions.DependencyInjection;

namespace FonRadar.Base.EventBus;

/// <summary>
/// This interface provides the user that which method can call by user after user call the AddEventBus method.
/// </summary>
public interface IEventBusServiceRegistration : IServiceCollection
{
}