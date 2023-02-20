using Microsoft.AspNetCore.Mvc;
using ReactBloagAPI.Data;
using ReactBloagAPI.DTOs;
using ReactBloagAPI.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ReactBloagAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogAPIRepo _repositroy;
        public BlogController(IBlogAPIRepo repositroy)
        {
            _repositroy = repositroy;
        }

        [HttpGet("blogs")]
        public ActionResult<IEnumerable<BlogOutDTO>> GetBlogs() 
        {
            IEnumerable<Blog> blogs = _repositroy.GetBlogs();
            IEnumerable<BlogOutDTO> b = blogs.Select(e => new BlogOutDTO
            {
                Id = e.Id,
                Author = e.Author,
                BlogBody = e.BlogBody,
                Title = e.Title,
                Tag = e.Tag,
            });
            return Ok(b);
        }
        [HttpGet("blogs/{ID}")]
        public ActionResult<BlogOutDTO> GetBlog(int id)
        {
            Blog blog = _repositroy.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            else
            {
                BlogOutDTO b = new() { 
                    Id = blog.Id, 
                    Author = blog.Author, 
                    BlogBody = blog.BlogBody, 
                    Title = blog.Title, 
                    Tag = blog.Tag 
                };
                return Ok(b);
            }
        }
        [HttpPost("blog/add")]
        public ActionResult<BlogOutDTO> AddBlog(BlogInputDTO blog)
        {
            Blog b = new()
            {
                Author = blog.Author,
                Title = blog.Title, 
                BlogBody = blog.BlogBody, 
                Tag = blog.Tag,
            };
            Blog addedBlog = _repositroy.AddBlog(b);
            BlogOutDTO blogOut = new () {
                Id = addedBlog.Id, 
                Author = addedBlog.Author, 
                Title= addedBlog.Title,
                BlogBody = addedBlog.BlogBody,
                Tag= addedBlog.Tag 
            };
            return CreatedAtAction(nameof(GetBlog), new { id = blogOut.Id }, blogOut);
        }
        [HttpGet("users")]
        public ActionResult<IEnumerable<UserOutDTO>> GetUsers() {
            IEnumerable<Users> users = _repositroy.GetUsers();
            IEnumerable<UserOutDTO> b = users.Select(e => new UserOutDTO
            {
                UserName = e.UserName
            });
            return Ok(b);
        }
        [HttpPost("addUser")]
        public ActionResult<UserOutDTO> Adduser(UserInputDTO user)
        {
            Users u = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password
            };
            Users addedUser = _repositroy.AddUser(u);
            UserOutDTO userOut = new()
            {
                FirstName= user.FirstName,
                LastName= user.LastName,    
                UserName = addedUser.UserName
            };
            return Ok(userOut);
        }
        [HttpGet("user/{USERNAME}")]
        public ActionResult<UserOutDTO> GetUser(string username)
        {
            Users user = _repositroy.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound(); 
            }
            else 
            {
                UserOutDTO u = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                };
                return Ok(u); 
            }
        }
    }
}
