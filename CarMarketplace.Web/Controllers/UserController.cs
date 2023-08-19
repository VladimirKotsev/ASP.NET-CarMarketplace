namespace CarMarketplace.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;

    using CarMarketplace.Web.Controllers.Common;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.Common;

    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }

        [HttpGet]
        [ActionName("Favourites")]
        public async Task<IActionResult> Favourites()
        {
            return View(await this.userService.GetUserFavouritesAsync(this.UserId));
        }

        [HttpPost]
        [Route("User/AddFavourite")]
        public async Task AddFavourite([FromBody] FavouriteDataViewModel data)
        {
            await this.userService.AddToUserFavouritesAsync(Guid.Parse(data.PostId), this.UserId);
        }

        [HttpPost]
        [Route("User/RemoveFavourite")]
        public async Task RemoveFavourite([FromBody] FavouriteDataViewModel data)
        {
            await this.userService.RemoveUserFavouritePostAsync(Guid.Parse(data.PostId), this.UserId);
        }

        [HttpGet]
        public async Task<IActionResult> Rented()
        {
            return View(await this.userService.GetUserRentedVehicle(this.UserId));
        }

        [HttpGet]
        public async Task<IActionResult> ReturnVehicle(Guid postId)
        {
            await this.userService.ReturnRentedCar(postId, this.UserId);

            return Redirect("/Rent/Catalog");
        }
    }
}
