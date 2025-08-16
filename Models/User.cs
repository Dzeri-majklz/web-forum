using System.ComponentModel.DataAnnotations;

namespace WebForum.Models
{
    public class User
    {


        public User()
        {
            int _id;
            if (Global.GlobalUsers == null)
            {
                _id = 0;
            }
            else
            {
                _id = Global.GlobalUsers.Count;
            }
            Id = _id;
        }
        public User(string login, string password, bool isManager)
        {
            int _id;
            if (Global.GlobalUsers == null)
            {
                _id = 0;
            }
            else
            {
                _id = Global.GlobalUsers.Count;
            }
            Id = _id;
            Login = login;
            Password = password;
            IsManager = isManager;
        }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength( 150,MinimumLength =3, ErrorMessage = "Длина строки должна быть не меньше 3 и не больше 150 символов")]

        public string? Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength( 150,MinimumLength =3, ErrorMessage = "Длина пароля должна быть не меньше 8 символов")]

        public string? Password { get; set; }

        public bool? IsManager  { get; set; }

        public List<Discussion> UserDiscussion = new List<Discussion>();

        public int Id { get; set; }


    }
}
