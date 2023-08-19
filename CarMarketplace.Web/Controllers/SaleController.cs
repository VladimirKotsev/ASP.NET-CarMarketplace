namespace CarMarketplace.Web.Controllers
{
    using System.Security.Claims; 

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Catalog;
    using Newtonsoft.Json;

    public class SaleController : BaseController
    {
        private readonly ISaleService catalogService;
        public SaleController(ISaleService _catalogService)
        {
            this.catalogService = _catalogService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search()
        {
            SearchViewModel model = new SearchViewModel();
            return View(await this.catalogService.GetSearchViewModelAsync(model));
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Search(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Search");
            }

            string serializedModel = JsonConvert.SerializeObject(model);
            HttpContext.Session.SetString("search", serializedModel);

            return Redirect("/Sale/Result");
        }

        [AllowAnonymous]
        [ActionName("Home")]
        public async Task<IActionResult> Home()
        {
            return View(await this.catalogService.GetLatestSalePostsAsync());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Result(int pageNum)
        {
            var searchViewModel = JsonConvert.DeserializeObject<SearchViewModel>(HttpContext.Session.GetString("search"));
            HttpContext.Session.SetString("action", "catalog");

            return View(await catalogService.GetFilteredSalePostsAsync(searchViewModel, pageNum));
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("Results")]
        public async Task<IActionResult> ResultGroups(string group, int pageNum)
        {
            HttpContext.Session.SetString("action", "groups");
            return this.View("Result", await this.catalogService.GetSalePostsByNationAsync(group, pageNum));
        }
    }
}
