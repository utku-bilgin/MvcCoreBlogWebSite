using Core.BaseEntities;
using Core.IBaseRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Base
{
    public class BaseStandartContextRepo<TEntity, TContext> : IBaseStandartContextRepo<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        public Task Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
