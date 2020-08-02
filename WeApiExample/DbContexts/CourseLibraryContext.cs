using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeApiExample.Entity;

namespace WeApiExample.DbContexts
{
    public class CourseLibraryContext : DbContext
    {
        public CourseLibraryContext(DbContextOptions options):base(options)
        {

        }
      public  DbSet<Author> Authors { get; set; }
        public  DbSet<Course> Courses { get; set; }
    }
}
