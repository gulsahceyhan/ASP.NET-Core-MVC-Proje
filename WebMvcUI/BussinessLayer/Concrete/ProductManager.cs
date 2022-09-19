using BusinessLayer.Abstract;
using BusinessLayer.FluentValidation;
using BusinessLayer.Results;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.PaginationHelper;
using EntityLayer.ViewModel;
using FluentValidation.Results;
using WebMvcUI.ViewModel;

namespace BusinessLayer.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;
        private readonly ProductValidator _validator;
        

        public ProductManager(IProductDal productDal, ProductValidator validator, ICategoryDal categoryDal)
        {
            _productDal=productDal;
            _validator = validator;
            _categoryDal = categoryDal;
        }
        public IDataResult<List<Product>> GetAllProductList()
        {
            var result = _productDal.List(t=>!t.IsDeleted);
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<Page<Product>> GetListToPaged(int pageIndex, int pageSize)
        {
            var pagedResult = _productDal.list(pageIndex, pageSize);
            return new SuccessDataResult<Page<Product>>(pagedResult);

        }

        public IDataResult<Product> ProductAdd(VM_ProductAdd entity)
        {
            Product mappedEntity = new()
            {
                CategoryID = entity.CategoryID,
                ProductName = entity.ProductName,
                UnitsInStock = entity.UnitsInStock,
                UnitPrice = entity.UnitPrice,
                QuantityPerUnit = entity.QuantityPerUnit,
                UnitsOnOrder = entity.UnitsOnOrder,
            };

            var cateId = _categoryDal.Get(t => t.CategoryName == entity.CategoryName).CategoryID;
            mappedEntity.CategoryID = cateId;

            ValidationResult validationResults = _validator.Validate(mappedEntity);

            if (validationResults.IsValid)
            {
                var result = _productDal.Add(mappedEntity);
                return new SuccessDataResult<Product>(result);
            }

            return null;
        }

        public IDataResult<Product> GetByID(int id)
        {
            var result = _productDal.Get(x => x.ProductID == id);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<Product> DeleteProduct(Product entity)
        {
            var deleteToEntity = _productDal.Get(t => t.ProductID == entity.ProductID);

            deleteToEntity.IsDeleted = true;
            _productDal.Delete(deleteToEntity);    

            return new SuccessDataResult<Product>();
        }


        public IDataResult<Product> UpdateProduct(VM_ProductUpdate entity)
        {
            Product mappedEntity = new()
            {
                CategoryID = entity.CategoryID,
                UnitPrice = entity.UnitPrice,
                ProductName = entity.ProductName,
                QuantityPerUnit = entity.QuantityPerUnit,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder,
                ProductID = entity.ProductID
            };
            

            _productDal.Update(mappedEntity);
            return new SuccessDataResult<Product>();
        }

        public IDataResult<Product> GetProductDetails(Product entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
