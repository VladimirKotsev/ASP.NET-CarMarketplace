namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
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
        [ActionName("Home")]
        public async Task<IActionResult> Home()
        {
            return View(await this.catalogService.GetLatestSalePostsAsync());
        }

        [AllowAnonymous]
        [ActionName("Catalog")]
        public async Task<IActionResult> Catalog()
        {
            return View("Catalog", await this.catalogService.GetLatestSalePostsAsync());
        }

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

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Catalog/SetViewData")]
        //public ActionResult SetViewData(ViewDataViewModel data)
        //{
        //    Console.WriteLine(data);
        //    ViewData[data.key] = data.value;
        //    return new EmptyResult();
        //}
    }
}
