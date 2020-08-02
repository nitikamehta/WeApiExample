 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeApiExample.Entity;
using WeApiExample.Model;
using WeApiExample.Services;

namespace WeApiExample.Controllers
{
    [Route("api/authors/{authorId}/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper Mapper;

        private readonly ICourseRepository CourseRepository;
        public CoursesController(IMapper mapper ,ICourseRepository courseRepository)
        {
           
            Mapper = mapper;
            CourseRepository = courseRepository;
        }


        public ActionResult<CourseDTO> getCourse(Guid authorId,Guid couseId)
        {
            if (!CourseRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var courseFromDb = CourseRepository.GetCourse(authorId,couseId);
            return Ok(Mapper.Map<CourseDTO>(courseFromDb));
        }

        public ActionResult<IEnumerable<CourseDTO>> getCourses(Guid authorId)
        {
            if (!CourseRepository.AuthorExists(authorId))
            {
                return NotFound();
            }
            var courseFromDb = CourseRepository.GetCourse(authorId);
            return Ok(Mapper.Map<CourseDTO>(courseFromDb));
        }
     
    }
}