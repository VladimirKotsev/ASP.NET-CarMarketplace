﻿namespace CarMarketplace.Web.Controllers
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
            return View();
        }

        [HttpPost]
        [Route("User/BecomeSeller")]
        public async Task<IActionResult> BecomeSeller(SellerPersonalInfoViewModel model)
        {
            bool isPhoneNumberTaken =
                await sellerService.SellerExistbyPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Seller with the provided phone number already exists!");
            }

            bool existingCity =
                await sellerService.CityExistByNameAsync(model.City);

            if (!existingCity)
            {
                ModelState.AddModelError(nameof(model.City), "The provided city name does not exist");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            await sellerService.RegisterUserAsSellerAsync(this.UserId, model);

            return RedirectToAction("Index", "Home");
        }
    }
}
