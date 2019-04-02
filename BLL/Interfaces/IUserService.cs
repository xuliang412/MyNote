using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.UserEntity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        int UpdateUser(User user);

        int UpdateUser(string userName,string password);

        int DeleteUserById(int userId);

        int DeleteUserByName(string userName);

        IEnumerable<User> SelectAllUser();

        User SelectUserById(int userId);

        User SelectUserByName(string userName);

        int AddUser(User user);

        int AddUser(string userName, string password);

        bool IsUserNameExsit(string userName);

        bool IsUserValidate(string userName, string password);
    }
}
