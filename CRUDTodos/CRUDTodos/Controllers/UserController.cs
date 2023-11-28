using Microsoft.AspNetCore.Mvc;
using CRUDTodos.Models;

namespace CRUDTodos.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("isAuth") == null)
            {
                return RedirectToAction("LoginForm","User");
            }
            return View();
        }
        public IActionResult LoginForm()
        {
            return View();
        }
        public IActionResult Login(User u)
        {
            if(ModelState.IsValid)
            {
                string password = new string(u.Password.Reverse().ToArray());
                if(u.Login == password)
                {
                    HttpContext.Session.SetString("isAuth","");
                    return RedirectToAction("Index","Todo");
                }
            }
            return View("LoginForm");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginForm");
        }
    }
}
