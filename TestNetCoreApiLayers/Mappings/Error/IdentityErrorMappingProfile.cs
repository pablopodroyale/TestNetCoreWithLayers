using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCore.Api.Mappings.Error
{
    public class IdentityErrorMappingProfile : Profile
    {
        public IdentityErrorMappingProfile()
        {
            CreateMap<IdentityError, Core.Model.Exception.Error>().ReverseMap();
        }
    }
}
