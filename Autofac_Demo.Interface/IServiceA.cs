using Autofac.Extras.DynamicProxy;
using Autofac_Demo.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac_Demo.Interface
{
    //标记AOP能在当前接口生效
    //[Intercept(typeof(CustomAutofacAop))]
    public interface IServiceA
    {
        public void Show();
    }
}
