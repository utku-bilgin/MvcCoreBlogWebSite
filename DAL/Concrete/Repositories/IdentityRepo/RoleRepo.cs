using DAL.Abstract;
using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repositories.IdentityRepo
{
    public class RoleRepo : IRoleRepo
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleRepo(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task Create(AppRole entity)
        {
            await _roleManager.CreateAsync(entity);
        }

        public async Task Delete(AppRole entity)
        {
            await _roleManager.DeleteAsync(entity);
        }

        public Task<AppRole> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppRole>> GetAll()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<AppRole> GetByIdAsysnc(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task Update(AppRole entity)
        {
            await _roleManager.UpdateAsync(entity);
        }
    }
}
