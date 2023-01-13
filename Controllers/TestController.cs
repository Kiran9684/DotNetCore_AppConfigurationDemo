using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_AppConfigurationDemo.Controllers
{
    public class TestController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
