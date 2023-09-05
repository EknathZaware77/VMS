using Microsoft.AspNetCore.Mvc;

namespace VMSApp.Controllers
{
    public class AboutController:Controller
    {


        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }





    }
}
