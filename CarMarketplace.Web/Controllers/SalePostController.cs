namespace CarMarketplace.Web.Controllers
{
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels.Catalog;
    using CarMarketplace.Web.ViewModels.SalePost;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    public class SalePostController : BaseController
    {
        private readonly ISalePostService salePostService;
        private readonly ISellerService sellerService;

        public SalePostController(ISalePostService _salePostService, ISellerService _sellerService)
        {
            this.salePostService = _salePostService;
            this.sellerService = _sellerService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await this.salePostService.GetSalePostByIdAsync(id));
        }

        [HttpPost]
        [ActionName("Post")]
        public async Task<IActionResult> Post(AddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", await this.salePostService.GetAddPostViewModelAsync(viewModel));
            }

            try
            {
                await this.salePostService.AddPostAsync(viewModel, await this.sellerService.GetSellerIdByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (InvalidOperationException error)
            {
                viewModel.ImagesErrorMessage = error.Message;
                return View("Add", await this.salePostService.GetAddPostViewModelAsync(viewModel));
            }


            return Redirect("/Seller/UserPosts");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid postId)
        {
            return View("Edit", await salePostService.GetEditViewModelByPostIdAsync(postId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            //To do
            return View("Edit");
        }

        [HttpGet]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddViewModel viewModel)
        {
            return View("Add", await this.salePostService.GetAddPostViewModelAsync(viewModel));
        }

        public async Task<IActionResult> Delete(Guid postId)
        {
            await this.salePostService.DeletePostAsync(postId);

            return Redirect("/Seller/UserPosts");
        }
    }
}
