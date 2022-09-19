using BusinessLayer.Abstract;
using BusinessLayer.Results;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService //Eger interface ile implementasyon yapıyorsak imzaları implemente etmemiz lazım
    {

        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> CategoryAdd(Category entity)
        {
            var result = _categoryDal.Add(entity);

            return new SuccessDataResult<Category>(result);
        }


        public IDataResult<List<Category>> GetAllCategoryList()
        {   //artık burada isDeleted alanları false olanları getireceğiz.
            var result = _categoryDal.List(t => !t.IsDeleted);
            return new SuccessDataResult<List<Category>>(result);
        }

        public IDataResult<Category> GetByID(int id)
        {
            var result =_categoryDal.Get(x => x.CategoryID == id);
            return new SuccessDataResult<Category>(result);
        }

        public IDataResult<Category> DeleteCategory(Category entity)
        {
            var deleteToEntity = _categoryDal.Get(t => t.CategoryID == entity.CategoryID);

            deleteToEntity.IsDeleted = true;
            _categoryDal.Delete(deleteToEntity);    //Delete methodu bir şey donmediginden bir atama yapamazsin.

            return new SuccessDataResult<Category>();
        }

        public IDataResult<Category> UpdateCategory(Category entity)
        {
          _categoryDal.Update(entity);
          return new SuccessDataResult<Category>();

        }
    }

}
