using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using checkoutconsole.Common;
using checkoutconsole.Common.Interfaces;
using checkoutconsole.Models;

namespace checkoutconsole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICheckoutService _checkoutService;

        public HomeController(ILogger<HomeController> logger, ICheckoutService checkoutService)
        {
            _logger = logger;
            _checkoutService = checkoutService;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel();
            vm.Products = _checkoutService.LoadProducts().ToList();
            vm.Items = new List<Common.Contracts.CartItem>();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            _checkoutService.CalculatePromotionOffer(model.Items);
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
