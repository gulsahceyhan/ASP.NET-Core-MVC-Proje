using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Results;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IOrderDetailService
    {
        IDataResult<List<OrderDetail>> GetAllList();
        IDataResult<OrderDetail> GetByID(int id);    
        IDataResult<OrderDetail> AddOrderDetail(OrderDetail entity);
        IDataResult<OrderDetail> DeleteOrderDetail(OrderDetail entity);
        IDataResult<OrderDetail> UpdateOrderDetail(OrderDetail entity);



    }
}
