namespace CarMarketplace.Web.Areas.Lender.Controllers
{
    using System.Security.Claims;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Areas.Lender.Controllers.Common;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using CarMarketplace.Web.ViewModels.SalePost;
    using CarMarketplace.Web.ViewModels.Seller;
    using Microsoft.AspNetCore.Mvc;

    public class LenderController : BaseController
    {
        private readonly ILenderService lenderService;
        private readonly IRentPostService postService;

        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        public LenderController(ILenderService lenderService, IRentPostService postService)
        {
            this.lenderService = lenderService;
            this.postService = postService;
        }

        [Route("Lender/UserPosts")]
        public async Task<IActionResult> UserPosts()
        {
            return View("LenderPosts", await this.lenderService.GetLenderPostsAsync(await this.lenderService.GetLenderIdByUserIdAsync(this.UserId)));
        }

        [HttpGet]
        [Route("Lender/Add")]
        public async Task<IActionResult> Add()
        {
            return View(await this.postService.GetAddViewModelAsync(new AddRentPostViewModel()));
        }

        [HttpPost]
        [ActionName("Post")]
        public async Task<IActionResult> Post(AddRentPostViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", await this.postService.GetAddViewModelAsync(viewModel));
            }

            try
            {
                await this.postService.AddPostAsync(viewModel, await this.lenderService.GetLenderIdByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (InvalidOperationException error)
            {
                viewModel.ImagesErrorMessage = error.Message;
                return View("Add", await this.postService.GetAddViewModelAsync(viewModel));
            }


            return Redirect("/Lender/UserPosts");
        }

        [Route("Lender/Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteDataViewModel model)
        {
            await this.postService.DeletePostAsync(model.PostId, model.CarId);

            return Redirect("/Lender/UserPosts");
        }
    }
}
