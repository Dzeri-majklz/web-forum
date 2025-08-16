using Microsoft.AspNetCore.Mvc;
using WebForum.Models;

namespace WebForum.Controllers
{
    public class UserController : Controller
    {
        public IActionResult CreateUser()
        {
            return View("CreateUser");
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if(ModelState.IsValid)
            {
                foreach (var item in Global.GlobalUsers)
                {
                    if (item.Login == user.Login)
                    {
                        ViewBag.ErrorCreateUser = "Пользователь с таким именем уже есть";
                        return View("CreateUser");

                    }

                }
                        Global.ActiveLocalUser = user;
                        Global.GlobalUsers.Add(new User(user.Login, user.Password, false));
                        return View("TrueCreateUser");
            }
            return View("CreateUser");

        }



        public IActionResult AuthenticationUser()
        {
            return View("AuthenticationUser");
        }
        [HttpPost]
        public IActionResult AuthenticationUser(User user)
        {

            if (ModelState.IsValid)
            {
                foreach (var item in Global.GlobalUsers)
                {
                    if(item.Login == user.Login && item.Password == user.Password)
                    {
                        Global.ActiveLocalUser = item;
                        return View("TrueAuthenticationUser");

                    }
                    
                }
                ViewBag.ErrorAuthenticationUser = "Неверный логин или пароль";
                return View("AuthenticationUser");
            }
            return View("AuthenticationUser");

        }
        public IActionResult Exit()
        {
            Global.ActiveLocalUser = null;
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
