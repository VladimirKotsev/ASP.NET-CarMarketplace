namespace CarMarketplace.Web.Controllers
{
    using System.Security.Claims; 

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Catalog;
    public class SaleController : BaseController
    {
        private readonly ISaleService catalogService;
        public SaleController(ISaleService _catalogService)
        {
            this.catalogService = _catalogService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            return View(await this.catalogService.GetSearchViewModelAsync(model));
        }

        [AllowAnonymous]
        [ActionName("Home")]
        public async Task<IActionResult> Home()
        {
            return View(await this.catalogService.GetLatestSalePostsAsync());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Result(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Search", model);
            }

            return View(await catalogService.GetFilteredSalePostsAsync(model));
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("Results")]
        public async Task<IActionResult> ResultGroups(string group)
        {
            return this.View("Result", await this.catalogService.GetSalePostsByNationAsync(group));
        }
    }
}
