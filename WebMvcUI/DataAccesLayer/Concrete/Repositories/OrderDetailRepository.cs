using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccesLayer.Concrete.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public OrderDetailRepository(Context context) : base(context)
        {
        }
    }
}
