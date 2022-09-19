using EntityLayer.Concrete;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.PaginationHelper;


namespace DataAccesLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        Page<T> list(int pageIndex, int pageSize);

        string Add(T entity); //burada liste seklinde ekleme yapmayacağım için service'te de liste almayı beklemem yanlıs olur...
        void Update(T entity);
        void Delete(T entity);  

        T Get(Expression<Func<T, bool>> filter); 
        List<T> List(Expression<Func<T, bool>>? filter);  //şartlı listeleme

        
    }
}
