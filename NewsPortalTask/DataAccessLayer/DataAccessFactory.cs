using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        static dotnetcourseEntities db;
        static DataAccessFactory()
        {
            db = new dotnetcourseEntities();
        }
        public static IRepository<News, int> NewsDataAccess()
        {
            return new NewsRepo(db);
        }
        public static IRepository<Category, int> CategoryDataAccess()
        {
            return new CategoryRepo(db);
        }
        public static IRepository<React, int> ReactDataAccess()
        {
            return new ReactRepo(db);
        }
        public static IRepository<Comment, int> CommentDataAccess()
        {
            return new CommentRepo(db);
        }
    }
}
