namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Services.Data.Models;
    using CarMarketplace.Web.Controllers.Common;

    public class CatalogController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Search()
        {
            return View(new CatalogSearchViewModel());
        }
    }
}
