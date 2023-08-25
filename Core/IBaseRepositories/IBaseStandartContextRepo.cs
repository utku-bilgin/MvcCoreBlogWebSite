using Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IBaseRepositories
{
    public interface IBaseStandartContextRepo<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {

    }
}
