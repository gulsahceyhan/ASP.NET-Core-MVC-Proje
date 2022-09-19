using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccesLayer.Concrete.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductDal

    {
        public ProductRepository(Context context) : base(context)
        {
        }

         private readonly Context context; 
        public List<ProductDetailDto> GetProductDetails()
        {
            using (context)
            {
                var result = from p in context.Products
                    join c in context.Categories
                        on p.ProductID equals c.CategoryID
                    select new ProductDetailDto
                    {
                        ProductID = p.ProductID, CategoryID = c.CategoryID, UnitsInStock = p.UnitsInStock,
                        QuantityPerUnit = p.QuantityPerUnit
                    }; 
                return result.ToList();
            }

            
        }
    }
}
