namespace CarMarketplace.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Web.ViewModels.SalePost;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        [AllowAnonymous]
        public async Task<IActionResult> DetailsReload([FromBody] FavouriteDataViewModel data)
        {
            return View("Details", await this.salePostService.GetSalePostByIdAsync(Guid.Parse(data.PostId)));
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
        [ActionName("Add")]
        public async Task<IActionResult> Add()
        {
            return View("Add", await this.salePostService.GetAddPostViewModelAsync(new AddViewModel()));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(EditViewModel viewModel, Guid postId)
        {
            ModelState.Clear();
            return View("Edit", await salePostService.GetEditViewModelByPostIdAsync(viewModel, postId));
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(EditViewModel viewModel, Guid postId)
        {
            viewModel.PostId = postId;

            if (viewModel.Images.Count > 9)
            {
                ModelState.AddModelError("Images", "Maximum number of photos in 9");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", viewModel);
            }

            try
            {
                await this.salePostService.EditPostByIdAsync(viewModel);

            }
            catch (InvalidOperationException error)
            {
                viewModel.ImagesErrorMessage = error.Message;
                return RedirectToAction("Edit", viewModel);
            }

            return Redirect("/Seller/UserPosts");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid postId, Guid carId)
        {
            await this.salePostService.DeletePostAsync(postId, carId);

            return Redirect("/Seller/UserPosts");
        }

        [HttpGet]
        [ActionName("Archive")]
        public async Task<IActionResult> Archive(Guid postId)
        {
            await this.salePostService.ArchivePostByIdAsync(postId);

            return Redirect("/Seller/UserPosts");
        }

    }
}
