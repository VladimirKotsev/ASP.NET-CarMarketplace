namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels.Seller;
    using CarMarketplace.Web.ViewModels.Catalog;
    using Microsoft.AspNetCore.Authorization;

    public class SellerController : BaseController
    {
        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        private readonly ISellerService sellerService;

        public SellerController(ISellerService _sellerService)
        {
            this.sellerService = _sellerService;
        }

        [HttpGet]
        [Route("User/BecomeSeller")]
        public async Task<IActionResult> BecomeSeller()
        {
            bool isSeller = await sellerService.SellerExistbyUserIdAsync(this.UserId);

            if (isSeller)
            {
                TempData["ErrorMessage"] = "You are already a seller!";

                return RedirectToAction("Index", "Home");
            }

            ViewData["Title"] = "seller";
            return View("BecomeProvider");
        }

        [HttpPost]
        [Route("User/BecomeSeller")]
        public async Task<IActionResult> BecomeSeller(SellerPersonalnfoViewModel model)
        {
            bool isPhoneNumberTaken =
                await sellerService.SellerExistbyPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Seller with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View("BecomeProvider");
            }

            await sellerService.RegisterUserAsSellerAsync(this.UserId, model);

            return RedirectToAction("Index", "Home");
        }

        [ActionName("UserPosts")]
        public async Task<IActionResult> UserPosts()
        {
            return View("UserPosts", await this.sellerService.GetSellerPostsAsync(await this.sellerService.GetSellerIdByUserIdAsync(this.UserId)));
        }
        
    }
}
