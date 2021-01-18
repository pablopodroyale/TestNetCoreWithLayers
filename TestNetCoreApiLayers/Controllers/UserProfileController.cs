using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Core.Bussines;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Model;

namespace TestNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private IUserBussines _userBussines;

        public UserProfileController(IUserBussines userBussines)
        {
            this._userBussines = userBussines;
        }

       
        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            ApplicationUserDto user = await _userBussines.FindByIdAsync(userId);
            if (user != null)
            {
                return new
                {
                    Nickname = user.Username,
                    Id = user.Id
                };
            }
            return null;
        }
    }
}
