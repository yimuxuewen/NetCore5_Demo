using Autofac;
using Autofac.Configuration;
using Autofac.Extras.DynamicProxy;
using Autofac.Features.ResolveAnything;
using Autofac_Demo.Common;
using Autofac_Demo.Interface;
using Autofac_Demo.Service;
using Autofac_Demo.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac_Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 构造函数创建A
            ////创建容器
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            //IContainer container = containerBuilder.Build();
            ////获取服务
            //IServiceA serviceA = container.Resolve<IServiceA>();
            //serviceA.Show();
            #endregion

            #region 注入方式
            #region 构造函数注入
            ////创建容器
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            //containerBuilder.RegisterType<ServiceB>().As<IServiceB>();
            //containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
            //IContainer container = containerBuilder.Build();
            ////获取服务
            //IServiceC serviceC = container.Resolve<IServiceC>();
            //serviceC.Show();
            #endregion

            #region 属性注入
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            //containerBuilder.RegisterType<ServiceB>().As<IServiceB>();
            //containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
            //containerBuilder.RegisterType<ServiceD>().As<IServiceD>().PropertiesAutowired();
            //IContainer container = containerBuilder.Build();
            ////获取服务
            //IServiceD serviceD = container.Resolve<IServiceD>();
            //serviceD.Show();

            #endregion

            #region 方法注入
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            //containerBuilder.RegisterType<ServiceB>().OnActivated(e=>e.Instance.SetService(e.Context.Resolve<IServiceA>())).As<IServiceB>();
            //containerBuilder.RegisterType<ServiceD>().As<IServiceD>().PropertiesAutowired();
            //IContainer container = containerBuilder.Build();
            ////获取服务
            //IServiceB serviceB = container.Resolve<IServiceB>();
            //serviceB.Show();

            #endregion
            #endregion

            #region 生命周期
            #region 瞬时生命周期
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerDependency();
            //IContainer container = containerBuilder.Build();
            ////获取服务
            //IServiceA serviceA = container.Resolve<IServiceA>();
            //IServiceA serviceA1 = container.Resolve<IServiceA>();
            //Console.WriteLine(object.ReferenceEquals(serviceA,serviceA1));
            #endregion

            #region 单例生命周期
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
            //IContainer container = containerBuilder.Build();
            ////获取服务
            //IServiceA serviceA = container.Resolve<IServiceA>();
            //IServiceA serviceA1 = container.Resolve<IServiceA>();
            //Console.WriteLine(object.ReferenceEquals(serviceA, serviceA1));
            #endregion

            #region 每个生命周期范围内一个实例
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerLifetimeScope();
            //IContainer container = containerBuilder.Build();
            //IServiceA serviceA5 = null;
            //IServiceA serviceA6 = null;

            //using (var scope=container.BeginLifetimeScope())
            //{
            //    IServiceA serviceA1 = scope.Resolve<IServiceA>();
            //    IServiceA serviceA2 = scope.Resolve<IServiceA>();
            //    serviceA5 = serviceA1;
            //    Console.WriteLine(object.ReferenceEquals(serviceA1, serviceA2));
            //}
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    IServiceA serviceA3 = scope.Resolve<IServiceA>();
            //    IServiceA serviceA4 = scope.Resolve<IServiceA>();
            //    serviceA5 = serviceA3;
            //    Console.WriteLine(object.ReferenceEquals(serviceA4, serviceA4));
            //}

            //Console.WriteLine(object.ReferenceEquals(serviceA5, serviceA6));
            #endregion

            #region 每个匹配生命周期范围内一个实例
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerMatchingLifetimeScope("Reaper");
            //IContainer container = containerBuilder.Build();
            //IServiceA serviceA5 = null;
            //IServiceA serviceA6 = null;

            //using (var scope = container.BeginLifetimeScope("Reaper"))
            //{
            //    IServiceA serviceA1 = scope.Resolve<IServiceA>();
            //    using (var scope1 = container.BeginLifetimeScope("Reaper"))
            //    {
            //        IServiceA serviceA2 = scope.Resolve<IServiceA>();
            //        Console.WriteLine(object.ReferenceEquals(serviceA1, serviceA2));
            //    }
            //    serviceA5 = serviceA1;
            //}
            //using (var scope = container.BeginLifetimeScope("Reaper"))
            //{
            //    IServiceA serviceA3 = scope.Resolve<IServiceA>();
            //    using (var scope1 = container.BeginLifetimeScope("Reaper"))
            //    {
            //        IServiceA serviceA4 = scope.Resolve<IServiceA>();
            //        Console.WriteLine(object.ReferenceEquals(serviceA3, serviceA4));
            //    }
            //    serviceA5 = serviceA3;
            //}

            //Console.WriteLine(object.ReferenceEquals(serviceA5, serviceA6));
            #endregion

            #region 每个请求一个实例
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerRequest();
            //IContainer container = containerBuilder.Build();

            #endregion
            #endregion

            #region Autofac配置文件加载
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //IConfigurationSource configurationSource = new JsonConfigurationSource()
            //{
            //    Path = "CfgFile/autofac.json",
            //    Optional = false,
            //    ReloadOnChange = true
            //};
            //configurationBuilder.Add(configurationSource);
            //ConfigurationModule configurationModule = new ConfigurationModule(configurationBuilder.Build());
            //containerBuilder.RegisterModule(configurationModule);

            //IContainer container = containerBuilder.Build();
            //IServiceA serviceA = container.Resolve<IServiceA>();
            //IServiceD serviceD = container.Resolve<IServiceD>();
            //serviceD.Show();
            #endregion

            #region 指定控制器实例让容器来创建
            //services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            #endregion

            services.AddControllersWithViews();

        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
            //containerBuilder.RegisterType<ServiceB>().As<IServiceB>().SingleInstance();
            //containerBuilder.RegisterType<ServiceC>().As<IServiceC>().SingleInstance();
            //containerBuilder.RegisterType<ServiceD>().As<IServiceD>().PropertiesAutowired().SingleInstance();
            //containerBuilder.RegisterType<ServiceE>().As<IServiceE>().SingleInstance();
            #region 注册所有控制器的关系+控制器实例化需要的所有组件
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            containerBuilder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired(new AutowiredPropertySelector());
            #endregion

            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
            //containerBuilder.RegisterType<ServiceUpdate>().As<IServiceA>().SingleInstance();

            ////Module方式注入
            ////containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource(t => t.IsAssignableTo<IServiceA>()));
            //containerBuilder.RegisterModule(new AutofacModule());

            #region Autofac的AOP支持
            //containerBuilder.RegisterModule(new AutofacModule());
            //containerBuilder.RegisterType(typeof(CustomAutofacAop));
            ////接口式AOP支持
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().EnableInterfaceInterceptors();
            #endregion

            #region Autofac的AOP支持
            //containerBuilder.RegisterModule(new AutofacModule());
            //containerBuilder.RegisterType(typeof(CustomAutofacAop));
            ////方法式AOP支持
            //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().EnableClassInterceptors();
            //containerBuilder.RegisterType<ServiceUpdate>().As<IServiceA>().EnableClassInterceptors();
            #endregion

            #region 一个接口多实现通过标记名
            containerBuilder.RegisterModule(new AutofacModule());
            containerBuilder.RegisterType(typeof(CustomAutofacAop));
            //方法式AOP支持
            containerBuilder.RegisterType<ServiceA>().Named<IServiceA>("ServiceA").EnableClassInterceptors();
            containerBuilder.RegisterType<ServiceUpdate>().Named<IServiceA>("ServiceUpdate").EnableClassInterceptors();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
