using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CommentRepo : IRepository<Comment,int>
    {
        News_PortalEntities _db;
        public CommentRepo(News_PortalEntities db)
        {
            _db = db;
        }

        public bool Add(Comment e)
        {
            _db.Comments.Add(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = _db.Comments.FirstOrDefault(en => en.Id == id);
            _db.Comments.Remove(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(Comment e)
        {
            var f = _db.Comments.FirstOrDefault(en => en.Id == e.Id);
            _db.Entry(f).CurrentValues.SetValues(e);
            return (_db.SaveChanges() > 0);
        }

        public List<Comment> Get()
        {
            return _db.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return _db.Comments.FirstOrDefault(en => en.Id == id);
        }

        public List<News> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDateCategory(DateTime dateTime, string category)
        {
            throw new NotImplementedException();
        }
    }
}
