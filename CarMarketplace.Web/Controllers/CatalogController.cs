namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;

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
        public async Task<IActionResult> Catalog()
        {
            return View(await this.catalogService.GetLatestSalePostsAsync());
        }
    }
}
