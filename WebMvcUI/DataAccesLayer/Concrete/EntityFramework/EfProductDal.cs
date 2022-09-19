using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccesLayer.Concrete.EntityFramework
{
    internal class EfProductDal : GenericRepository<Product>, IProductDal

    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
