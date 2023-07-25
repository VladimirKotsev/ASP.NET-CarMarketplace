namespace CarMarketplace.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        public UserController()
        {
                
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
