using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.DTOs;

namespace DataAccesLayer.Abstract
{
    public interface IProductDal: IRepository<Product>
    {
        public List<ProductDetailDto> GetProductDetails();
    }
}
