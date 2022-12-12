using System.ComponentModel.DataAnnotations;

namespace ReactBloagAPI.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string BlogBody { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Tag { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
