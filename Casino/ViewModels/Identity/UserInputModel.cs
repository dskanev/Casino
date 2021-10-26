using AutoMapper;
using Casino.Common.Data.Mappings;
using Casino.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.ViewModels.Identity
{
    public class UserInputModel : IMapping
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<UserInputModel, LoginFormModel>()
                .ForMember(x => x.Email, opt => opt.MapFrom(dest => dest.Email))
                .ForMember(x => x.Password, opt => opt.MapFrom(dest => dest.Password));
        }
    }
}
