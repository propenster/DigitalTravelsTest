using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Domain.Models.Auth;
using UBAInterviewPrepAPI.Domain.Models.IdentityAuthDtos;

namespace UBAInterviewPrepAPI.Domain.AutomapperProfiles
{
    public class MyProfiles : Profile
    {

        public MyProfiles()
        {
            CreateMap<UserSignUpDto, User>().ForMember(target => target.UserName, option => option.MapFrom(source => source.Email));
        }
    }
}
