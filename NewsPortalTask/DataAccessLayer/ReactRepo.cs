using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ReactRepo : IRepository<React,int>
    {
        dotnetcourseEntities _db;
        public ReactRepo(dotnetcourseEntities db)
        {
            _db = db;
        }

        public bool Add(React e)
        {
            _db.Reacts.Add(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = _db.Reacts.FirstOrDefault(en => en.Id == id);
            _db.Reacts.Remove(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(React e)
        {
            var f = _db.Reacts.FirstOrDefault(en => en.Id == e.Id);
            _db.Entry(f).CurrentValues.SetValues(e);
            return (_db.SaveChanges() > 0);
        }

        public List<React> Get()
        {
            return _db.Reacts.ToList();
        }

        public React Get(int id)
        {
            return _db.Reacts.FirstOrDefault(en => en.Id == id);
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
