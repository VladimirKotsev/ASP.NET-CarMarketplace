namespace CarMarketplace.Web.Controllers
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;
    using CarMarketplace.Web.Controllers.Common;

    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Web.ViewModels.User;

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
        public async Task<IActionResult> AddFavourite([FromBody] FavouriteDataViewModel data)
        {
            await this.userService.AddToUserFavouritesAsync(Guid.Parse(data.PostId), data.UserId);

            return RedirectToAction("Favourites");
        }
    }
}
