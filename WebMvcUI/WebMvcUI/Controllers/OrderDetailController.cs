using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebMvcUI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _service;

        public OrderDetailController(IOrderDetailService service)
        {
            _service = service;
        }
        public IActionResult GetAllList()
        {
            var orderDetails = _service.GetAllList();
            return View(orderDetails);
        }
    }
}
