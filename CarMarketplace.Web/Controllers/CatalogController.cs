namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
    using System.ComponentModel.DataAnnotations;
    using CarMarketplace.Web.ViewModels;

    public class CatalogController : BaseController
    {
        private readonly ICatalogService catalogService;
        public CatalogController(ICatalogService _catalogService)
        {
            this.catalogService = _catalogService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search()
        {
            return View(await this.catalogService.GetSearchViewModelAsync());
        }

        [AllowAnonymous]
        [ActionName("CatalogHome")]
        public async Task<IActionResult> CatalogHome()
        {
            return View("CatalogHome", await this.catalogService.GetLatestSalePostsAsync());
        }

        [AllowAnonymous]
        [ActionName("Catalog")]
        public async Task<IActionResult> Catalog()
        {
            return View("Catalog" ,await this.catalogService.GetLatestSalePostsAsync());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Catalog/SetViewData")]
        public ActionResult SetViewData(ViewDataViewModel data)
        {
            Console.WriteLine(data);
            ViewData[data.key] = data.value;
            return new EmptyResult();
        }
    }
}
