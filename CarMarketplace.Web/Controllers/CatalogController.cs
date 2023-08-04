namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels;
    using CarMarketplace.Web.ViewModels.Catalog;

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
        [ActionName("Home")]
        public async Task<IActionResult> Home()
        {
            return View(await this.catalogService.GetLatestSalePostsAsync());
        }

        [AllowAnonymous]
        public ActionResult Result(SearchViewModel model)
        {
            return View("Catalog");
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ActionName("Catalog")]
        //public async Task<IActionResult> Catalog(SearchViewModel model)
        //{
        //    return View("Catalog", await this.catalogService.GetLatestSalePostsAsync());
        //}

        [ActionName("AddPost")]
        public IActionResult Add()
        {
            return View("AddPost");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await this.catalogService.GetSalePostByIdAsync(id));
        }
    }
}
