using BLL.Interfaces;
using DAL.DbContexts;
using Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserManager
{
    public class UserService : IUserService
    {
        private MyNoteContext _db;
        private object _lock = new object();

        public UserService()
        {
            _db = MyNoteContext.CreateInstance();
        }

        public int AddUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int AddUser(string userName, string password)
        {
            try
            {
                _db.Users.Add(new User { UserName = userName, Password = password });
                _db.SaveChanges();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int DeleteUserById(int userId)
        {
            try
            {
                User delUser = _db.Users.FirstOrDefault(x => x.UserId == userId);
                if (delUser != null)
                {
                    _db.Users.Remove(delUser);
                    _db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int DeleteUserByName(string userName)
        {
            try
            {
                User delUser = _db.Users.FirstOrDefault(x => x.UserName == userName);
                if (delUser != null)
                {
                    _db.Users.Remove(delUser);
                    _db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool IsUserNameExsit(string userName)
        {
            return _db.Users.Any(x => x.UserName.Equals(userName));
        }

        public IEnumerable<User> SelectAllUser()
        {
            return _db.Users;
        }

        public User SelectUserById(int userId)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public User SelectUserByName(string userName)
        {
            return _db.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public int UpdateUser(User user)
        {
            try
            {
                User updateUser = _db.Users.FirstOrDefault(x => x.UserId == user.UserId);
                if (updateUser != null)
                {
                    updateUser.UserName = user.UserName;
                    updateUser.Password = user.Password;
                    _db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public int UpdateUser(string userName, string password)
        {
            try
            {
                User updateUser = _db.Users.FirstOrDefault(x => x.UserName == userName);
                if (updateUser != null)
                {
                    updateUser.Password = password;
                    _db.SaveChanges();
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public bool IsUserValidate(string userName, string password)
        {
            User objUser = _db.Users.FirstOrDefault(x => x.UserName == userName);
            if (objUser != null)
            {
                return objUser.Password.Equals(password);
            }
            return false;
        }
    }
}
