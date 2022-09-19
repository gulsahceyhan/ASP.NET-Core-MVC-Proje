using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Results;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class OrderDetailManager:IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal;

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public IDataResult<List<OrderDetail>> GetAllList()
        {
            var result = _orderDetailDal.List(null);
            return new SuccessDataResult<List<OrderDetail>>(result);
        }

        public IDataResult<OrderDetail> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<OrderDetail> AddOrderDetail(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<OrderDetail> DeleteOrderDetail(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<OrderDetail> UpdateOrderDetail(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
