using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Model;
using TestNetCore.Core.Repository;
using TestNetCore.Dal.Contracts;
using TestNetCore.Dal.Repository;

namespace TestNetCore.Dal
{
    public class UserApplicattionDal : IUserApplicattionDal
    {
        IUserRepository repository;
        IMapper mapper;
        private readonly TestNetCoreDbContext _context;
        private ApplicattionUserRepository _applicattionUserRepository;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserApplicattionDal(IUserRepository repository, IMapper mapper, TestNetCoreDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterAsync(CreateUserDto createUserDto)
        {
            var aplicationUser = mapper.Map<CreateUserDto, ApplicationUser>(createUserDto);
            var result = await repository.RegisterAsync(aplicationUser, createUserDto.Password);
            return result;
        }

        public async Task<ApplicationUserDto> FindByNamesyncAsync(LoginUserDto loginUserDto)
        {
            var result = await _userManager.FindByNameAsync(loginUserDto.Nickname);
            ApplicationUserDto ret = null;
            if (result != null)
            {
                ret = mapper.Map<ApplicationUser, ApplicationUserDto>(result);
            }
            return ret;
        }

        public async Task<bool> CheckPasswordAsync(LoginUserDto userDto)
        {
            var applicationUser = await _userManager.FindByNameAsync(userDto.Nickname);
            applicationUser.User = null;
            bool ret = false;
            if (applicationUser != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(applicationUser, userDto.Password, false);
                if (result.Succeeded)
                {
                    ret = true;
                }
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
            return ret;
        }
    }
}
