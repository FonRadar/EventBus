# EventBus 

## **FonRadar.Base**

The EventBus library provides core requirements of eventing. They are listed below:

### `ISubscriptionManager`
SubscriptionManager helps to matching events and their handlers and finding all registered handlers by event. 

## **Usage** 

To use this library, you should follow the below steps.

### **Add to project**

You need to add the package to your project with using following command:

```
dotnet add package FonRadar.Base.EventBus
```

Also you can use Nuget UI on your IDE to get the EventBus library.

### **Required Namaspace**

You must be sure the below namespace already decleared in your code file.

```csharp
using FonRadar.Base.EventBus
```

### **Dependency Registration**

```csharp
services.AddEventBus();
```

After call the `AddEventBus()` it returns `IEventBusServiceCollection` that can be using to specialize service registration methods.

The `IEventBusServiceCollection` is inherited from `IServiceCollection`.

Also this way is easy to register internal dependencies.