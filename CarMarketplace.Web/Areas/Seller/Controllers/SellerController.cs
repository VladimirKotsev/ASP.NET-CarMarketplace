namespace CarMarketplace.Areas.Seller.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Seller;
    using CarMarketplace.Web.Areas.Seller.Controllers.Common;
    using CarMarketplace.Services;
    using CarMarketplace.Web.ViewModels.SalePost;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Common;
    using CarMarketplace.Data;
    using Microsoft.EntityFrameworkCore;

    public class SellerController : BaseController
    {
        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        private readonly ISellerService sellerService;
        private readonly ISalePostService salePostService;
        private readonly CarMarketplaceDbContext dbContext;

        public SellerController(ISellerService _sellerService, ISalePostService _salePostService, CarMarketplaceDbContext _dbContext)
        {
            this.sellerService = _sellerService;
            this.salePostService = _salePostService;
            this.dbContext = _dbContext;
        }

        [Route("Seller/UserPosts")]
        public async Task<IActionResult> UserPosts()
        {
            return View("UserPosts", await this.sellerService.GetSellerPostsAsync(await this.sellerService.GetSellerIdByUserIdAsync(this.UserId)));
        }

        [Route("Seller/Archive")]
        public async Task<IActionResult> Archive()
        {
            return View(await this.sellerService.GetSellerArchivePostsAsync(await this.sellerService.GetSellerIdByUserIdAsync(this.UserId)));
        }

        [Route("Seller/ActivatePost")]
        public async Task<IActionResult> ActivatePost([FromBody] string postId)
        {
            await this.sellerService.ActiveSellerPostAsync(Guid.Parse(postId));

            return Redirect("/Seller/Archive");
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
        public async Task<IActionResult> Delete([FromBody] Guid postId, Guid carId)
        {
            await this.salePostService.DeletePostAsync(postId, carId);

            return Redirect("/Seller/UserPosts");
        }

        public async Task<IActionResult> ArchivePost(Guid postId)
        {
            await this.salePostService.ArchivePostByIdAsync(postId);

            return Redirect("/Seller/UserPosts");
        }
    }
}
