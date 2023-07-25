namespace CarMarketplace.Web.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels;
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
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