using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeApiExample.Helpers;

namespace WeApiExample.Profiles
{
    public class AuthorsProfile:Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entity.Author, Model.AuthorDTO>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).
                ForMember(
                dest=>dest.Age,
                opt=>opt.MapFrom(src=>src.DateOfBirth.GetCurrentAge())
                );
        }
    }
}
