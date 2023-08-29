using Core.BaseEntities;
using System.Linq.Expressions;

namespace DAL.Abstract
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync(T entity);
        
        /// <summary>
        /// birden çok veri döndüren
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// bir adet veri döndürür
        /// </summary>
        /// <returns></returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// ID ye karşılık gelen entity bul
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByGuidAsync(Guid id);

        /// <summary>
        /// Bir adet değeri update yap
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        /// <summary>
        /// Değerini ver içindeki işlemleri ona göre yaptır
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Örnek kullanım: article içinde kaç adet nesne var
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
