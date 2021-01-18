using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestNetCore.Core.Bussines;
using TestNetCore.Core.Contracts;
using TestNetCore.Core.Dto;
using TestNetCore.Core.Helper;
using TestNetCore.Core.Model.Enum;
using TestNetCore.Core.Model.Exception;
using TestNetCore.Dal.Contracts;

namespace TestNetCore.Bussines
{
    public class UserBussines : IUserBussines
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IUserApplicattionDal userApplicationDal;
        private readonly Core.Shared.ApplicattionSettings _applicationSettings;

        public UserBussines(IMapper mapper, IUserApplicattionDal userApplicationDal, IOptions<Core.Shared.ApplicattionSettings> appSettings)
        {
            //this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.userApplicationDal = userApplicationDal;
            this._applicationSettings = appSettings.Value;
        }

        public async Task<ApplicationUserDto> CreateUser(CreateUserDto user)
        {
            //var userMapped = _mapper.Map<CreateUserDto, Core.Model.User>(user);
            //await _unitOfWork.Users
            //  .AddAsync(userMapped);
            //await _unitOfWork.CommitAsync();
            //var userCreatedMapped = _mapper.Map<Core.Model.User, UserDto>(userMapped);
            //return userCreatedMapped;
            return null;
        }

        public async Task DeleteUser(ApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAll()
        {
            //var users = await _unitOfWork.Users.GetAllAsync();
            //IEnumerable<UserDto> ret = _mapper.Map<IEnumerable<Core.Model.User>,IEnumerable<UserDto>>(users);
            //return ret;
            return null;
        }

        public async Task<ApplicationUserDto> GetById(int id)
        {
            //var user = await _unitOfWork.Users.GetByIdAsync(id);
            //UserDto ret = _mapper.Map<Core.Model.User, UserDto>(user);
            //return ret;
            return null;
        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            CustomException customException;
            List<Error> errors = new List<Error>();

            try
            {
                var result = await this.userApplicationDal.FindByNamesyncAsync(loginUserDto);
                if (result != null)
                {
                    var checkPass = await this.userApplicationDal.CheckPasswordAsync(loginUserDto);
                    if (checkPass)
                    {
                        string secretKey = _applicationSettings.Jwt_Secret;
                        var tokenDescriptor = new SecurityTokenDescriptor()
                        {
                            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                           {
                               new Claim("UserID", result.Id.ToString())
                           }),
                            Expires = DateTime.UtcNow.AddMinutes(5),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                        var token = tokenHandler.WriteToken(securityToken);
                        return token;
                    }
                    else
                    {
                        Error error = new Error(Errors.ERROR_PASSWORD_INVALID);
                        errors.Add(error);
                        customException = new CustomException(errors);
                        throw customException;
                    }

                }
                else
                {
                    Error error = new Error(Errors.ERROR_USERNAME_INVALID);
                    errors.Add(error);
                    customException = new CustomException(errors);
                    throw customException;
                }
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                errors.Add(ErrorHelper.GetError());
                customException = new CustomException(errors);
                throw customException;
            }
        }

        public async Task<bool> Register(CreateUserDto user)
        {
            CustomException customException;
            try
            {
                var result = await this.userApplicationDal.RegisterAsync(user);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    var errorsIdentity = _mapper.Map<IEnumerable<IdentityError>, IEnumerable<Error>>(result.Errors);
                    customException = new CustomException(errorsIdentity);
                    throw customException;

                }
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                List<Error> errors = new List<Error>();
                errors.Add(ErrorHelper.GetError());
                customException = new CustomException(errors);
                throw customException;
            }
        }

        public async Task UpdateUser(ApplicationUserDto userToUpdate, ApplicationUserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUserDto> FindByIdAsync(string userId)
        {
            List<Error> errors = new List<Error>();
            CustomException customException;
            try
            {
                ApplicationUserDto result = await this.userApplicationDal.FindByIdAsync(userId);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    Error error = new Error(Errors.USER_INVALID);
                    errors.Add(error);
                    customException = new CustomException(errors);
                    throw customException;

                }
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                errors.Add(ErrorHelper.GetError());
                customException = new CustomException(errors);
                throw customException;
            }
        }
    }
}
