namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Security.Claims;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Web.ViewModels.User;

    public class UserController : BaseController
    {
        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        private readonly ISellerService sellerService;
        private readonly ILenderService lenderService;

        public UserController(ISellerService _sellerService, ILenderService _lenderService)
        {
            this.sellerService = _sellerService;
            this.lenderService = _lenderService;
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

            return View();
        }

        [HttpPost]
        [Route("User/BecomeSeller")]
        public async Task<IActionResult> BecomeSeller(UserPersonalnfoViewModel model)
        {
            bool isPhoneNumberTaken =
                await sellerService.SellerExistbyPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Seller with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await sellerService.RegisterUserAsSellerAsync(this.UserId, model);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Route("User/BecomeLender")]
        public async Task<IActionResult> BecomeLender()
        {
            bool isLender = await lenderService.LenderExistbyUserIdAsync(this.UserId);

            if (isLender)
            {
                TempData["ErrorMessage"] = "You are already a lender!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Route("User/BecomeLender")]
        public async Task<IActionResult> BecomeLender(UserPersonalnfoViewModel model)
        {
            bool isPhoneNumberTaken =
                await lenderService.LenderExistbyPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Lender with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await lenderService.RegisterUserAsLenderAsync(this.UserId, model);

            return RedirectToAction("Index", "Home");
        }
    }
}
