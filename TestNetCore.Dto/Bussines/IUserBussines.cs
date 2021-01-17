using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;

namespace TestNetCore.Core.Bussines
{
    public interface IUserBussines
    {
        Task<IEnumerable<ApplicationUserDto>> GetAll();
        Task<ApplicationUserDto> GetById(int id);
        Task<ApplicationUserDto> CreateUser(CreateUserDto newMusic);
        Task UpdateUser(ApplicationUserDto musicToBeUpdated, ApplicationUserDto music);
        Task DeleteUser(ApplicationUserDto music);
        Task<bool> Register(CreateUserDto createUserDto);
        Task<string> Login(LoginUserDto loginUserDto);
    }
}
