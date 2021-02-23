using Castle.DynamicProxy;
using System;

namespace Autofac_Demo.Common
{
    public class CustomAutofacAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Show方法执行前");
            invocation.Proceed();
            Console.WriteLine("Show方法执行后");
        }
    }
}
