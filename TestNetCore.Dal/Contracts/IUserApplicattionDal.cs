using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Model;

namespace TestNetCore.Dal.Contracts
{
    public interface IUserApplicattionDal
    {
        public Task<IdentityResult> RegisterAsync(CreateUserDto createUserDto);

        Task<ApplicationUserDto> FindByNamesyncAsync(LoginUserDto loginUserDto);

        Task<bool> CheckPasswordAsync(LoginUserDto loginUserDto);
    }
}
