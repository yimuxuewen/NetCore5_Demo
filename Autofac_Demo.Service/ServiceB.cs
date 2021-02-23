using Autofac_Demo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac_Demo.Service
{
    public class ServiceB : IServiceB
    {
        public IServiceA _iserviceA = null;

        public void SetService(IServiceA serviceA)
        {
            _iserviceA = serviceA;
        }
        public ServiceB(IServiceA serviceA)
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
        public void Show()
        {
            Console.WriteLine("BBBB");
        }
    }
}
