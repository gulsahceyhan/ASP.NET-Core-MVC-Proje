using Microsoft.AspNetCore.Mvc;

namespace WebMvcUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult GetAllList()
        {
            return View();
        }
    }
}
