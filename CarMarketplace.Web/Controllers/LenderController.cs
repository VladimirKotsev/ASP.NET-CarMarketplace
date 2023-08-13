namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;

    public class LenderController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
