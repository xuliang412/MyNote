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

        int DeleteUserById(string userId);

        int DeleteUserByName(string userName);

        IEnumerable<User> SelectAllUser();

        User SelectUserById(string userId);

        User SelectUserByName(string userName);

        int AddUser(User user);

        bool IsUserNameExsit(string userName);

        bool IsUserValidate(User user);
    }
}
