using Core.IBaseRepositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IRoleRepo : IIdentityRepo<AppRole>
    {
        Task<AppRole> GetByIdAsysnc(int id);
    }
}
