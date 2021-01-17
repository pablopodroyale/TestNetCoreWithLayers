using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Model;

namespace TestNetCore.Core.Repository
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<IdentityResult> RegisterAsync(ApplicationUser applicationUser, string password);
    }
}
