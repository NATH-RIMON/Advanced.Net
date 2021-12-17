using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NewsRepo : IRepository<News, int>
    {
        News_PortalEntities _db;
        public NewsRepo(News_PortalEntities db)
        {
            _db = db;
        }
        public bool Add(News e)
        {
            _db.News.Add(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = _db.News.FirstOrDefault(en => en.Id == id);
            _db.News.Remove(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(News e)
        {
            var f = _db.News.FirstOrDefault(en => en.Id == e.Id);
            _db.Entry(f).CurrentValues.SetValues(e);
            return (_db.SaveChanges() > 0);
        }

        public List<News> Get()
        {
            return _db.News.ToList();
        }

        public News Get(int id)
        {
            return _db.News.FirstOrDefault(en => en.Id == id);
        }

        public List<News> GetByDate(DateTime dateTime)
        {
            var e=(from news in _db.News where news.DatePosted==dateTime select news).ToList();
            return e;
        }
        public List<News> GetByCategory(string category)
        {
            var e = (from news in _db.News where news.Category == category select news).ToList();
            return e;
        }
        public List<News> GetByDateCategory(DateTime dateTime, string category)
        {
            var e = (from news in _db.News where news.DatePosted == dateTime && news.Category == category select news).ToList();
            return e;
        }
    }
}
