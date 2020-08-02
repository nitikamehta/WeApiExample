using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeApiExample.Entity;
using WeApiExample.Helpers;
using WeApiExample.Model;
using WeApiExample.ResourceParameters;
using WeApiExample.Services;

namespace WeApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper mapper;

        public AuthorsController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        [HttpGet]
        public IActionResult GetAuthors([FromQuery]AuthorsResourceParameter authorsResourceParameter)
        {
            var AuthorsFromRepo = _courseRepository.GetAuthors(authorsResourceParameter.MainCategory,authorsResourceParameter.SearchQuery);
            return Ok(mapper.Map<IEnumerable<AuthorDTO>>(AuthorsFromRepo));


        }
        [HttpGet("{id}")]
        public IActionResult GetAuthors(Guid  id)
        {
            var AuthorsFromRepo = _courseRepository.GetAuthor(id);
            if (AuthorsFromRepo != null)
            {
                return Ok(mapper.Map<AuthorDTO>(AuthorsFromRepo));
            }
            else return NotFound();


        }

        [HttpPost]
        
        public IActionResult AddAuthor(Author author)
        {
            _courseRepository.AddAuthor(author);
            return Created("",author);
        }
    }
}