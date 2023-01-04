using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReactBloagAPI.Models;
using System.Reflection.Metadata;

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
            IEnumerable<Blog> blogs = _dbContext.Blogs.ToList(); 
            return blogs;
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
        public IEnumerable<Users> GetUsers()
        {
          IEnumerable<Users> users = _dbContext.Users.ToList();
          return users;
        }

        public Users GetUserById(int id)
        {
            Users user = _dbContext.Users.FirstOrDefault(e => e.Id == id);
            return user;
        }
        public Users AddUser(Users user)
        {
            EntityEntry<Users> e = _dbContext.Users.Add(user);
            Users b = e.Entity;
            _dbContext.SaveChanges();
            return b;

        }


    }
}
