namespace CarMarketplace.Web.Controllers
{
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels.Rent;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

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


        [HttpGet]
        public async Task<IActionResult> RentVehicle(Guid postId)
        {
            var model = await rentService.GetRentingPostViewModel(postId, User.Identity!.Name!);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RentVehicle(RentingViewModel viewModel, Guid postId)
        {
            viewModel.PostId = postId;
            viewModel.Email = User.Identity!.Name!;

            if (!ModelState.IsValid)
            {
                return View(postId);
            }

            await rentService.RentVehicleAsync(User.FindFirstValue(ClaimTypes.NameIdentifier), viewModel);

            return RedirectToAction("Catalog");
        }
    }
}
