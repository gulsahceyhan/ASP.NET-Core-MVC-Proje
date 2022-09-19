using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        
    }
}
