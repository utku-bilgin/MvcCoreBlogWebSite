using Core.IBaseRepositories;
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
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<AppRole> _userManager;

        public UserRepo(UserManager<AppRole> userManager)
        {
            _userManager = userManager;
        }

        public async Task Create(AppRole entity)
        {
            await _userManager.CreateAsync(entity);
        }

        public async Task Delete(AppRole entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public Task<AppRole> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppRole>> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public async Task<AppRole> GetByIdAsync(int id)
        {
            //_userManager.FindByNameAsync();
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task Update(AppRole entity)
        {
            await _userManager.UpdateAsync(entity);
        }

    }
}
