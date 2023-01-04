using System.ComponentModel.DataAnnotations;

namespace ReactBloagAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
