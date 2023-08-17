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
    }
}
