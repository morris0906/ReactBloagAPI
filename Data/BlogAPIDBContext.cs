using Microsoft.EntityFrameworkCore;
using ReactBloagAPI.Models;

namespace ReactBloagAPI.Data
{
    public class BlogAPIDBContext: DbContext
    {
        public BlogAPIDBContext(DbContextOptions<BlogAPIDBContext> options): base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
