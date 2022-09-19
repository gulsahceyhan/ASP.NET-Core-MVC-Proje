using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Results;
using EntityLayer.Concrete;
using EntityLayer.PaginationHelper;
using EntityLayer.ViewModel;
using WebMvcUI.ViewModel;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAllProductList();
        IDataResult<Page<Product>> GetListToPaged(int pageIndex, int PageSize);

        IDataResult<Product> ProductAdd(VM_ProductAdd entity);

        IDataResult<Product> GetByID(int id);

        IDataResult<Product> DeleteProduct(Product entity);
        IDataResult<Product> UpdateProduct(VM_ProductUpdate entity);
        IDataResult<Product>GetProductDetails(Product entity);
        
    }
}
