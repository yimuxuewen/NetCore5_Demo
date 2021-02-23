using Autofac.Extras.DynamicProxy;
using Autofac_Demo.Common;
using Autofac_Demo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac_Demo.Service
{
    [Intercept(typeof(CustomAutofacAop))]
    public class ServiceA : IServiceA
    {
        public ServiceA()
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
        public virtual void Show()
        {
            Console.WriteLine("AAAA"); 
        }
    }
}
