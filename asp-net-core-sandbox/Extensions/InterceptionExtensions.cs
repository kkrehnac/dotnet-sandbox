using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace asp_net_core_sandbox.Extensions;

public static class InterceptionExtensions
{
    public static void AddInterceptedSingleton<TIService, TService, TInterceptor>(this IServiceCollection services)
        where TIService : class
        where TService : class, TIService
        where TInterceptor : class, IInterceptor
    {
        services.TryAddSingleton<IProxyGenerator, ProxyGenerator>();
        services.AddSingleton<TService>();
        services.TryAddTransient<TInterceptor>();
        services.AddSingleton(provider =>
        {
            var proxyGenerator = provider.GetRequiredService<IProxyGenerator>();
            var service = provider.GetRequiredService<TService>();
            var interceptor = provider.GetRequiredService<TInterceptor>();
            return proxyGenerator.CreateInterfaceProxyWithTarget<TIService>(service, interceptor);
        });
    }
}
