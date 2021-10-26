using AutoMapper;
using Casino.Common.Data.Mappings;
using Casino.UserHistory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casino.UserHistory.Models.UserDetails
{
    public class UserDetailsInputModel : IMapping
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public long StreetNumber { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<UserDetailsInputModel, Address>()
                .ForMember(e => e.UserId, opt => opt.MapFrom(dest => dest.UserId))
                .ForMember(e => e.Country, opt => opt.MapFrom(dest => dest.Country))
                .ForMember(e => e.City, opt => opt.MapFrom(dest => dest.City))
                .ForMember(e => e.Street, opt => opt.MapFrom(dest => dest.Street))
                .ForMember(e => e.StreetNumber, opt => opt.MapFrom(dest => dest.StreetNumber));

            mapper.CreateMap<UserDetailsInputModel, Data.Models.UserDetails>()
                .ForMember(e => e.UserId, opt => opt.MapFrom(dest => dest.UserId))
                .ForMember(e => e.FirstName, opt => opt.MapFrom(dest => dest.FirstName))
                .ForMember(e => e.LastName, opt => opt.MapFrom(dest => dest.LastName))
                .ForMember(e => e.PersonalEmail, opt => opt.MapFrom(dest => dest.PersonalEmail))
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(dest => dest.PhoneNumber));
        }
    }
}
