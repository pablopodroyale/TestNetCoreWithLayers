using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Model;
using TestNetCore.Core.Repository;

namespace TestNetCore.Dal.Repository
{
    public class ApplicattionUserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public ApplicattionUserRepository(TestNetCoreDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) : base(context)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        //public override async Task<IEnumerable<User>> GetAllAsync()
        //{
        //    return await Context.Set<User>()
        //                        //.Include(x => x.Phones)
        //                        .ToListAsync();
        //}


        public async Task<IdentityResult> RegisterAsync(ApplicationUser applicationUser, string password)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);
            return result;
        }

        ValueTask<ApplicationUser> IRepository<ApplicationUser>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ApplicationUser>> IRepository<ApplicationUser>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        private TestNetCoreDbContext GetContext
        {
            get { return Context as TestNetCoreDbContext; }
        }
    }
}
