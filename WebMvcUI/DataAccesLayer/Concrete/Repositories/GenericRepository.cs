using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;
using EntityLayer.PaginationHelper;

namespace DataAccesLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            T entity;
        }

        public List<T> List(Expression<Func<T, bool>>? filter)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList(); 
        }

        public void Delete(T entity)
        {
            _dbSet.Update(entity);  //burada db den kesin  olarak silmek istemedigimizden sadece update islemi yapmalıyız(isDeleted alanı true yapıalcak)
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>>? filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public Page<T> list(int pageIndex, int pageSize)
        {
            var result = _dbSet.ToPaged(pageIndex, pageSize);

            return result;
        }

        public string Add(T entity)
        {
            _dbSet.Add(entity);
            var result = _context.SaveChanges();

            if (result > 0)
            {
                return $"{entity} başarıyla eklendi";
            }
            return "Bir hata olustu.";
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return;
            }

            throw new Exception("---");
        }

    }
}
