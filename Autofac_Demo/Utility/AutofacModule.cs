using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac_Demo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac_Demo.Utility
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t=>t.IsAssignableTo<IServiceA>()));
        }
    }
}
