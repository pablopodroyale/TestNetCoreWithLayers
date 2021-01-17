using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNetCore.Api.Extensions;
using TestNetCore.Core.Bussines;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Helper;
using TestNetCore.Core.Model;
using TestNetCore.Core.Model.Exception;

namespace TestNetCore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : AppBaseController
    {
        private IUserBussines _userBussines;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly Serilog.ILogger _log;//For Context Specifies The Class Which The Log Is Intended For


        public UserController(IUserBussines userBussines, IMapper mapper, IOptions<ApplicationSettings> options, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : base(options)
        {
            this._userBussines = userBussines;
            this._mapper = mapper;
            this._userManager = userManager;
            this._signInManager = signInManager;
            _log = Log.ForContext<UserController>();
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<ApplicationUserDto>>> GetAll()
        {
            var users = await _userBussines.GetAll();
            return Ok(users.ToList());
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<ApplicationUserDto>>> Get(int id)
        {
            var user = await _userBussines.GetById(id);
            return Ok(user);
        }

        //[HttpPost("")]
        //public async Task<ActionResult<CreateUserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState); // this needs refining, but for demo it is ok
        //    }

        //    var newUser = await _userBussines.CreateUser(createUserDto);

        //    var userCreated = await _userBussines.GetById(newUser.Id);

        //    return Ok(userCreated);
        //}

        [HttpPost("")]
        public async Task<ActionResult<ServiceResultDto<bool>>> Register([FromBody] CreateUserDto createUserDto)
        {
            _log.ForContext("UserName", "PEPE").Information("Called Register");
            ServiceResultDto<bool> resultDto = new ServiceResultDto<bool>();

            if (!ModelState.IsValid)
            {
               
                var errors = ModelState.SelectMany(x => x.Value.Errors)
                           .Select(z => new Error() 
                           {
                                Description = z.ErrorMessage
                           })
                           .ToList();
                _log.ForContext("UserName", "Anonimo").Error(String.Join(";", errors));
                resultDto.Errors = errors;
                resultDto.Succedded = false;
                return Ok(ModelState); // this needs refining, but for demo it is ok
            }

            try
            {
                var result = await _userBussines.Register(createUserDto);
                resultDto.Succedded = true;
                return Ok(resultDto);
            }
            catch (CustomException e)
            {
                _log.ForContext("UserName", "PEPE").Error(String.Join(";", e.Errors.Select(x => x.Description).ToList()));
                resultDto.Errors = e.Errors.ToList();
                resultDto.Succedded = false;
                return Ok(resultDto);
            }
            catch (Exception e)
            {
                _log.Error("Error User -> Get Method Error Details: {0}", e); 
                List<Error> errors = new List<Error>();
                errors.Add(ErrorHelper.GetError());
                resultDto.Succedded = false;
                return BadRequest(resultDto);
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<ServiceResultDto<bool>>> Login([FromBody] LoginUserDto loginUserDto)
        {
            _log.ForContext("UserName", "PEPE").Information("Called Register");
            ServiceResultDto<string> resultDto = new ServiceResultDto<string>();

            if (!ModelState.IsValid)
            {

                var errors = ModelState.SelectMany(x => x.Value.Errors)
                           .Select(z => new Error()
                           {
                               Description = z.ErrorMessage
                           })
                           .ToList();
                _log.ForContext("UserName", "Anonimo").Error(String.Join(";", errors));
                resultDto.Errors = errors;
                resultDto.Succedded = false;
                return Ok(resultDto); // this needs refining, but for demo it is ok
            }

            try
            {
                var result = await _userBussines.Login(loginUserDto);
                resultDto.Succedded = true;
                resultDto.obj = result;
                return Ok(resultDto);
            }
            catch (CustomException e)
            {
                _log.ForContext("UserName", "Anonimo").Error(String.Join(";", e.Errors.Select(x => x.Description).ToList()));
                resultDto.Errors = e.Errors.ToList();
                resultDto.Succedded = false;
                return Ok(resultDto);
            }
            catch (Exception e)
            {
                _log.Error("Error User -> Get Method Error Details: {0}", e);
                List<Error> errors = new List<Error>();
                errors.Add(ErrorHelper.GetError());
                resultDto.Succedded = false;
                return BadRequest(resultDto);
            }
        }

    }
}
