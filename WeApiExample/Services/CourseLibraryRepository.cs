using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeApiExample.DbContexts;
using WeApiExample.Entity;

namespace WeApiExample.Services
{
    public class CourseLibraryRepository : ICourseRepository, IDisposable
    {
        private readonly CourseLibraryContext _context;
        public CourseLibraryRepository(CourseLibraryContext context)
        {
            _context =context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddCourse(Guid AuthorId,Course course)
        {
            if (AuthorId == null)
            {
                throw new ArgumentNullException(nameof(AuthorId));
            }
            if (course== null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            course.AuthorId = AuthorId;
            _context.Courses.Add(course);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public bool AuthorExists(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _context.Authors.Any(a => a.Id == authorId);
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList<Author>();
        }
        public Course GetCourse(Guid authorId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }
            return _context.Courses
              .Where(c => c.AuthorId == authorId).FirstOrDefault();
        }

        public Course GetCourse(Guid authorId, Guid courseId)
        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            return _context.Courses
              .Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefault();
        }

        public Author GetAuthor(Guid id)
        {
            return _context.Authors.FirstOrDefault(e => e.Id == id);
        }
        public void AddAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            // the repository fills the id (instead of using identity columns)
            author.Id = Guid.NewGuid();

            foreach (var course in author.Courses)
            {
                course.Id = Guid.NewGuid();
            }

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public IEnumerable<Author> GetAuthors(string Category, string SearchString)
        {
            if (string.IsNullOrWhiteSpace(Category)&& string.IsNullOrWhiteSpace(SearchString))
            {
                return GetAuthors();

            }
            var collection = _context.Authors as IQueryable<Author>;
            if (!string.IsNullOrWhiteSpace(Category))
            {
               Category= Category.Trim();
                collection = collection.Where(a => a.MainCatogory== Category);   
            }

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                SearchString = SearchString.Trim();
                collection = collection.Where(a => a.MainCatogory.Contains(SearchString)
                ||a.FirstName.Contains(SearchString)
                ||a.LastName.Contains(SearchString));
            }

            return collection.ToList();
        }
    }
}
