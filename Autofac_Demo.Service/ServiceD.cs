using Autofac_Demo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac_Demo.Service
{
    public class ServiceD : IServiceD
    {
        public string Name { get; set; }

        public IServiceA _iserviceA {get;set;}

        public IServiceB _iserviceB { get; set; }
        public IServiceC _iserviceC { get; set; }

        public ServiceD()
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }

        public void Show()
        {
            _iserviceB.Show();
            Console.WriteLine("DDDD");
        }
    }
}
