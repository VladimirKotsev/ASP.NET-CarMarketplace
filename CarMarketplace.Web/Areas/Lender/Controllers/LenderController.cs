namespace CarMarketplace.Web.Areas.Lender.Controllers
{
    using System.Security.Claims;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.Areas.Lender.Controllers.Common;
    using CarMarketplace.Web.ViewModels.RentPosts;
    using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Add()
        {
            return View();
        }
    }
}
