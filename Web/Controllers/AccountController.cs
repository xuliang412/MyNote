using BLL.Interfaces;
using Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Infrastructure;
using System.Web.Security;
using System.Security.Principal;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var userService = IocManager.Rosolve<IUserService>();
                if (userService.IsUserValidate(user))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName,false);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError(nameof(user.Password),"用户名或密码错误");
            }
            return View(user);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}