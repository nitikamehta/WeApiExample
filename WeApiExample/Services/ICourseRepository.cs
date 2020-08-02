using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeApiExample.Entity;

namespace WeApiExample.Services
{
   public interface ICourseRepository
    {
        public IEnumerable<Author> GetAuthors();
        public IEnumerable<Author> GetAuthors(string Category,string SearchString);


        public void AddAuthor(Author author);
        public Author GetAuthor(Guid id);
        public bool AuthorExists(Guid authorId);
        public Course GetCourse(Guid authorId);
        public Course GetCourse(Guid authorId,Guid CourseId);

    }
}
