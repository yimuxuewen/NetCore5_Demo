using Autofac_Demo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac_Demo.Service
{
    public class ServiceC : IServiceC
    {
        public ServiceC(IServiceB serviceB)
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
        public void Show()
        {
            Console.WriteLine("CCCC");
        }
    }
}
