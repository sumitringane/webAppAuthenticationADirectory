using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AzureWebAppAuth.Models;
using Microsoft.AspNetCore.Http.Headers;
namespace AzureWebAppAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            List<string> keys = new List<string>();
            String[] Name = new String[1];
            String[] id = new String[1];
            String[] token = new String[1];
            foreach (var obj in Request.Headers.Keys)
            {
                keys.Add(obj.ToString());
                Name=Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"];
                id = Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"];
                token = Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"];
            }
            ViewBag.Keys = keys;
            ViewBag.Name = Name;
            ViewBag.id = id;
            ViewBag.token = token;
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
