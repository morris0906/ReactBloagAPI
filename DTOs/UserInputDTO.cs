using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ReactBloagAPI.DTOs
{
    public class UserInputDTO
    {

        public string FistName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
