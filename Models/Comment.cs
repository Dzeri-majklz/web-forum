using System.ComponentModel.DataAnnotations;

namespace WebForum.Models
{
    public class Comment
    {
        [Required(ErrorMessage = "Коментарий не может быть пустым")]
        [StringLength(150, ErrorMessage = "Длина коментария должна быть не больше 150 символов")]
        public string? Text {  get; set; }

        public User? User { get; set; }
    }
}
