using System;
using System.Diagnostics;
using DAL.DbContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.UserEntity;
using System.Linq;
using Web.Infrastructure;
using BLL.Interfaces;
using BLL;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EF_Test()
        {
            MyNoteContext context = MyNoteContext.CreateInstance();
            context.Users.Add(new User { UserName = "zhangsan", Password = "1" });
            context.SaveChanges();
            Debug.Print(context.Users.FirstOrDefault().UserName);
        }

        [TestMethod]
        public void Update_User_Test()
        {
            IocManager.RegisterIocContainer(typeof(BLLWinsorInstaller).Assembly.FullName);

            var userService = IocManager.Rosolve<IUserService>();
            userService.IsUserValidate(new User { UserName = "李四", Password = "123" });
        }
    }
}
