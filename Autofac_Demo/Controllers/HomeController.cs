using Autofac;
using Autofac_Demo.Interface;
using Autofac_Demo.Models;
using Autofac_Demo.Service;
using Autofac_Demo.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        #region 属性注入
        //[Autowired]
        //private IServiceA ServiceA1 { get; set; }
        //private IServiceB ServiceB1 { get; set; }
        //private IServiceC ServiceC1 { get; set; }
        //private IServiceD ServiceD1 { get; set; }
        //private IServiceE ServiceE1 { get; set; } 
        #endregion

        #region 构造函数注入
        //private readonly IServiceA _serviceA;
        //private readonly IServiceB _serviceB;
        //private readonly IServiceC _serviceC;
        //private readonly IServiceD _serviceD;
        //private readonly IServiceE _serviceE;

        //public HomeController(ILogger<HomeController> logger, IServiceA serviceA, IServiceB serviceB, IServiceC serviceC, IServiceD serviceD, IServiceE serviceE)
        //{
        //    _logger = logger;
        //    _serviceA = serviceA;
        //    _serviceB = serviceB;
        //    _serviceC = serviceC;
        //    _serviceD = serviceD;
        //    _serviceE = serviceE;
        //} 
        #endregion


        #region 单抽象多实例
        //private readonly IEnumerable<IServiceA> _serviceA_list;
        //private readonly ServiceA _serviceA;
        //private readonly ServiceUpdate _serviceAUpdate;

        //public HomeController(ILogger<HomeController> logger, IEnumerable<IServiceA> serviceA_list,ServiceA serviceA, ServiceUpdate serviceAUpdate)
        //{
        //    _logger = logger;
        //    _serviceA_list = serviceA_list;
        //    _serviceA = serviceA;
        //    _serviceAUpdate = serviceAUpdate;
        //}
        #endregion

        #region Autofac的接口式AOP
        //private readonly IServiceA _serviceA;

        //public HomeController(ILogger<HomeController> logger, IServiceA serviceA)
        //{
        //    _logger = logger;
        //    _serviceA = serviceA;
        //}
        #endregion

        #region Autofac的方法式AOP
        //private readonly IEnumerable<IServiceA> _serviceA_list;

        //public HomeController(ILogger<HomeController> logger, IEnumerable<IServiceA> serviceA_list)
        //{
        //    _logger = logger;
        //    _serviceA_list = serviceA_list;
        //}
        #endregion

        #region 一个对象多个实现 通过标识获取
        /// <summary>
        /// Autofac 数据上下文
        /// </summary>
        private readonly IComponentContext _componentContext;
        private readonly IServiceA  _serviceA;
        private readonly IServiceA _serviceUpdate;

        public HomeController(ILogger<HomeController> logger, IComponentContext componentContext)
        {
            _logger = logger;
            _componentContext = componentContext;
            _serviceA = _componentContext.ResolveNamed<IServiceA>("ServiceA");
            _serviceUpdate = _componentContext.ResolveNamed<IServiceA>("ServiceUpdate");
        }
        #endregion

        public IActionResult Index()
        {
            _serviceA.Show();
            _serviceUpdate.Show();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
