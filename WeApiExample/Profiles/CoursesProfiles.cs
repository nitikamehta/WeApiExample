using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeApiExample.Model;

namespace WeApiExample.Profiles
{
    public class CoursesProfiles:Profile
    {
        public CoursesProfiles()
        {
            CreateMap<Entity.Course, CourseDTO>();
        }
    }
}
