namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services;
    using CarMarketplace.Services.Contracts;
    using System.Security.Claims;
    using CarMarketplace.Web.ViewModels.Lender;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class LenderController : BaseController
    {
        private readonly ILenderService lenderService;

        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        public LenderController(ILenderService lenderService)
        {
            this.lenderService = lenderService;
        }

        [HttpGet]
        [Route("User/BecomeLender")]
        public async Task<IActionResult> BecomeLender()
        {
            bool isLender = await this.lenderService.LenderExistbyUserIdAsync(this.UserId);

            if (isLender)
            {
                TempData["ErrorMessage"] = "You are already a seller!";

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Route("User/BecomeLender")]
        public async Task<IActionResult> BecomeLender(LenderPersonalInfoViewModel model)
        {
            bool isPhoneNumberTaken =
                await this.lenderService.LenderExistbyPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Lender with the provided phone number already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await this.lenderService.RegisterUserAsLenderAsync(this.UserId, model);
            }
            catch (ArgumentException exp)
            {
                ModelState.AddModelError(nameof(model.City), exp.Message);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
