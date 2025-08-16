using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class DiscussionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewDiscussion(int idDiscussion)
        {
            
            ViewBag.idDiscussion = idDiscussion;
            return View();
        }
        public IActionResult CreateDiscussions()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDiscussions(Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                Discussion discussion2 = new Discussion(discussion.Topic,discussion.Text);
                discussion2.UserId = Global.ActiveLocalUser.Id;
                Global.ActiveLocalUser.UserDiscussion.Add(discussion2);
                Global.GlobalDiscussion.Add(discussion2);
                return View("Index");

            }
            return View();
        }
    }
}
