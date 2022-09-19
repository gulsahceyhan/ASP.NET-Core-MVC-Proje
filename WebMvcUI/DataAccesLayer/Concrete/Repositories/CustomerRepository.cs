using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccesLayer.Concrete.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>, ICustomerDal
    {
        public CustomerRepository(Context context) : base(context)
        {
        }
    }
}
