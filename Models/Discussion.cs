using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebForum.Models
{
    public class Discussion 
    {

 
        public Discussion()
        {
            int _id;
            if(Global.GlobalDiscussion == null)
            {
                _id = 0;
            }
            else
            {
                _id = Global.GlobalDiscussion.Count;
            }
            Id = _id;
        }
        public Discussion(string topic,string text)
        {
            int _id;
            if (Global.GlobalDiscussion == null)
            {
                _id = 0;
            }
            else
            {
                _id = Global.GlobalDiscussion.Count;
            }
            Id = _id;
            Topic = topic;
            Text = text;
        }

        [Required(ErrorMessage = "Не указана тема")]
        public string? Topic { get; set; }
        [Required(ErrorMessage = "Обсуждение не может быть пустым")]
        public string? Text { get; set; }

        public int UserId { get; set; }

        public List<Comment>? Commenter = new List<Comment>();

        public int Id { get; set; }
    }
}
