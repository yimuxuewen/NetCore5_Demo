using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac_Demo.Utility
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutowiredAttribute:Attribute
    {
    }
}
