namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels;
    using CarMarketplace.Web.ViewModels.Catalog;
    using System.Diagnostics.Contracts;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using CarMarketplace.Services;
    using System.Security.Claims;

    public class CatalogController : BaseController
    {
        private readonly ICatalogService catalogService;
        private readonly ISellerService sellerService;
        public CatalogController(ICatalogService _catalogService, ISellerService _sellerService)
        {
            this.catalogService = _catalogService;
            this.sellerService = _sellerService;
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
                return this.View("Search", await this.catalogService.GetSearchViewModelAsync(model));
            }

            return View(await catalogService.GetFilteredSalePostsAsync(model));
        }

        [HttpPost]
        [ActionName("Post")]
        public async Task<IActionResult> Post(AddCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPost", await this.catalogService.GetAddPostViewModelAsync(viewModel));
            }
            try
            {
                await this.catalogService.AddPostAsync(viewModel, await this.sellerService.GetSellerIdByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception)
            {

                throw;
            }


            return Redirect("/Colletion/UserPosts");
        }

        [HttpGet]
        [ActionName("AddPost")]
        public async Task<IActionResult> Add(AddCarViewModel viewModel)
        {
            return View("AddPost", await this.catalogService.GetAddPostViewModelAsync(viewModel));
        }

        public async Task<IActionResult> Delete(Guid postId)
        {
            await this.catalogService.DeletePostAsync(postId);

            return Redirect("User/UserPosts");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await this.catalogService.GetSalePostByIdAsync(id));
        }
    }
}
