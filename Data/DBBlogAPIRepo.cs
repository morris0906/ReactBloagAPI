using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReactBloagAPI.Models;

namespace ReactBloagAPI.Data
{
    public class DBBlogAPIRepo:IBlogAPIRepo
    {
        private readonly BlogAPIDBContext _dbContext;
         public DBBlogAPIRepo(BlogAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Blog> GetBlogs() { 
            IEnumerable<Blog> blogs = _dbContext.Blogs.ToList<Blog>(); return blogs;
        }
        public Blog GetBlogById(int id)
        {
            Blog blog = _dbContext.Blogs.FirstOrDefault(e => e.Id == id);
            return blog;
        }
        public Blog AddBlog(Blog blog)
        {
            EntityEntry<Blog> e = _dbContext.Blogs.Add(blog);
            Blog b = e.Entity;
            _dbContext.SaveChanges();
            return b;
        }
    }
}
