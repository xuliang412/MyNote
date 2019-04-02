using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Infrastructure;
using System.Web.Security;
using System.Security.Principal;
using Web.Models;

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
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userService = IocManager.Rosolve<IUserService>();
                if (userService.IsUserValidate(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(nameof(model.Password), "用户名或密码错误");
            }
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userService = IocManager.Rosolve<IUserService>();
                if (!userService.IsUserNameExsit(model.UserName))
                {
                    if (!model.Password.Equals(model.ConfirmPassword))
                    {
                        ModelState.AddModelError(nameof(model.ConfirmPassword), "两次密码不一致");
                    }
                    else
                    {
                        userService.AddUser(model.UserName,model.Password);
                        return JavaScript("alert('注册成功')");
                    }
                }
                else
                {
                    ModelState.AddModelError(nameof(model.UserName), "用户名已存在");
                }
            }
            return View(model);
        }
    }
}