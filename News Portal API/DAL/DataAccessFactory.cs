using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static NewsMSEntities db;
        static DataAccessFactory()
        {
            db = new NewsMSEntities();
        }
        public static IRepository<News, int> NewsDataAccess()
        {
            return new NewsRepo(db);
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepository<Comment, int> CommentDataAccess()
        {
            return new CommentRepo(db);
        }

        public static IRepository<React, int> ReactDataAccess()
        {
            return new ReactRepo(db);
        }
    }
}
