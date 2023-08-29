using Core.BaseEntities;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        /// <summary>
        /// kaç tane entitynin olduğundan bağımsız olarak bir yapı gerçekleşecek.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> GetRepository<T>() where T : class, IBaseEntity, new();

        /// <summary>
        /// Async yapılarda kullanılacak
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Async olmayan bir yapı olması durumunda kullanılacak
        /// </summary>
        /// <returns></returns>
        int Save();
    }
}
