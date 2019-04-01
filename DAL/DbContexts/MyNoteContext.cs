using Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbContexts
{
    public sealed class MyNoteContext : DbContext
    {
        private static MyNoteContext _instance = new MyNoteContext();
        private object obj = new object();

        private DbSet<User> _users;

        public DbSet<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                lock (obj)
                {
                    _users = value;
                }
            }
        }

        private MyNoteContext() : base("MyNoteContext")
        {

        }

        public static MyNoteContext CreateInstance()
        {
            return _instance;
        }

    }
}
