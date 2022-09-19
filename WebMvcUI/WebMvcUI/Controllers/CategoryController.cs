using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebMvcUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUserCredential _userCredential;
        private readonly ICategoryService _service;
        private readonly CategoryValidator _validator;

        public CategoryController(ICategoryService service, IUserCredential userCredential, CategoryValidator validator)
        {
            _service = service;
            _userCredential = userCredential;
            _validator = validator;
        }


        public IActionResult GetAllList()
        {

            var categories = _service.GetAllCategoryList(); //bu sekilde service abstraction ı  yapılmalı
            return View(categories);
        }

        [HttpGet] //actionın get actionı oldugunu bildirir.
        public IActionResult AddCategory()//View ismiyle buradaki ismin aynı olmasına dikkat et!
        {
            return View();
        }

        [HttpPost] //actionın post actionı oldugunu bildirir.
        public IActionResult AddCategory(Category entity)   //ekrana nav bar iki buton ekleyelim
        {
            //bu altta olusturdugun obje orneginde verdigin validasyonları kontrol ediyorsun.!
            ValidationResult validationResults = _validator.Validate(entity);

            if (validationResults.IsValid)
            {
                _service.CategoryAdd(entity);
                return RedirectToAction("GetAllList");

            }
            else
            {
                foreach (var item in validationResults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(); 
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var category = _service.GetByID(id);    //isimlendirmeler önemli unutma!

            return View(category.Data);
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category) //burada bize gelen category nesnesi artık silinecek category nesnesi olmalıdır
        {
            var result = _service.DeleteCategory(category);

            if (result.Success)
            {
                return RedirectToAction("GetAllList");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _service.GetByID(id); 
            return View(category.Data);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            var result = _service.UpdateCategory(category);
            if (result.Success)
            {
                return RedirectToAction("GetAllList");
            }

            return View();

        }

    }
}
