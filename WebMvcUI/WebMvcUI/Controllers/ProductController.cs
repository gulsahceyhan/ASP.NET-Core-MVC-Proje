using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using EntityLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using WebMvcUI.ViewModel;
namespace WebMvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ProductValidator _validator;

        public ProductController(IProductService service, ProductValidator validator)
        {
            _service = service;
            _validator = validator;
        }


        public IActionResult GetAllList(int pageIndex, int pageSize)
        {
            var products = _service.GetAllProductList();
            return View(products);
        }

        [HttpGet("paged")]
        public IActionResult GetPagedList(int pageIndex, int pageSize=20)
        {
            var products = _service.GetListToPaged(pageIndex, pageSize);
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ProductAdd(VM_ProductAdd entity)
        {
            _service.ProductAdd(entity);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var product = _service.GetByID(id);    

            return View(product.Data);
        }

        [HttpPost]
        public IActionResult DeleteProduct(Product product) 
        {
            var result = _service.DeleteProduct(product);

            if (result.Success)
            {
                return RedirectToAction("GetAllList");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = _service.GetByID(id);
            return View(product.Data);
        }

        [HttpPost]
        public IActionResult UpdateProduct(VM_ProductUpdate entity)
        { 
            _service.UpdateProduct(entity);

            return RedirectToAction("GetAllList");

        }
    }
}
