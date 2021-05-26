using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBAInterviewPrepAPI.Models.Auth;
using UBAInterviewPrepAPI.Models.IdentityAuthDtos;

namespace UBAInterviewPrepAPI.AutomapperProfiles
{
    public class MyProfiles : Profile
    {

        public MyProfiles()
        {
            CreateMap<UserSignUpDto, User>().ForMember(target => target.UserName, option => option.MapFrom(source => source.Email));
        }
    }
}
