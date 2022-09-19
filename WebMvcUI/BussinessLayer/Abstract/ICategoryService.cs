using BusinessLayer.Results;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAllCategoryList();
        IDataResult<Category> CategoryAdd(Category entity);
        IDataResult<Category> GetByID(int id);
        IDataResult<Category> DeleteCategory(Category entity);
        IDataResult<Category> UpdateCategory(Category entity);
    }
}
