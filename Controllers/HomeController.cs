using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecSample.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SecSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string s)
        {
            // Sql Injection http://projects.webappsec.org/w/page/13246963/SQL%20Injection
            try
            {
                var cmd = new SqlCommand($"Select * from mytable where name='{s}'");
                cmd.ExecuteNonQuery();

            }
            catch
            {

            }

            return View();
        }

        public string Privacy(string myParam)
        {
            // not XSS
            return "Value " + myParam;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
