using System.ComponentModel.DataAnnotations;

namespace ReactBloagAPI.DTOs
{
    public class BlogInputDTO
    {
        public string Title { get; set; }
        public string BlogBody { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public DateTime DateTime { get; set; }
    }
}
