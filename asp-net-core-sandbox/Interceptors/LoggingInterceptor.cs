using Castle.DynamicProxy;

namespace asp_net_core_sandbox.Interceptors;

public class LoggingInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine($"I am an interceptor BEFORE invoke of {invocation.Method.Name}");
        // before invoked method
        invocation.Proceed();
        // after invoked method
        Console.WriteLine($"I am an interceptor AFTER invoke of {invocation.Method.Name}");
    }
}
