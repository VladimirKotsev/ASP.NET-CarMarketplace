namespace CarMarketplace.Web.Controllers
{
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Controllers.Common;
    using Microsoft.AspNetCore.Mvc;

    public class RentController : BaseController
    {
        private readonly IRentService rentService;

        public RentController(IRentService _rentService)
        {
            this.rentService = _rentService;
        }

        public async Task<IActionResult> Catalog()
        {
            return View(await rentService.GetRentPostViewModelAsync());
        }

        public async Task<IActionResult> Details(Guid postId)
        {
            var model = await rentService.GetPostDetailsByIdAsync(postId);

            return View(model);
        }
    }
}
