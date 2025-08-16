using Microsoft.AspNetCore.Mvc;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public IActionResult CreateComment(Comment comment, int idDiscussion)
        {
            if (ModelState.IsValid)
            { 
                Discussion ActiveDiscussion = Global.GlobalDiscussion[idDiscussion];
                comment.User = Global.ActiveLocalUser;
                ActiveDiscussion.Commenter.Add(comment);

            }
            ViewBag.idDiscussion = idDiscussion;
            return View("~/Views/Discussions/ViewDiscussion.cshtml");
        }
    }
}
