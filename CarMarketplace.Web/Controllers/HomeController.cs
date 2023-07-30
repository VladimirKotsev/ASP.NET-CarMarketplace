namespace CarMarketplace.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels;
    using CarMarketplace.Services.Contracts;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await this.homeService.GetSalePostsAsync());
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}