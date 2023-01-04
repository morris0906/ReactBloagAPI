using ReactBloagAPI.Models;

namespace ReactBloagAPI.Data
{
    public interface IBlogAPIRepo
    {
        IEnumerable<Blog> GetBlogs();   
        Blog GetBlogById(int id);
        Blog AddBlog(Blog blog);
        IEnumerable<Users> GetUsers();
        Users GetUserById(int id);
        Users AddUser(Users user);
    }
}
