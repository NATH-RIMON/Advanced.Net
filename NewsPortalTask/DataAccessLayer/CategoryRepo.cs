using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryRepo : IRepository<Category,int>
    {
        News_PortalEntities _db;
        public CategoryRepo(News_PortalEntities db)
        {
            _db = db;
        }

        public bool Add(Category e)
        {
            _db.Categories.Add(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = _db.Categories.FirstOrDefault(en => en.Id == id);
            _db.Categories.Remove(e);
            return (_db.SaveChanges() > 0);
        }

        public bool Edit(Category e)
        {
            var f = _db.Categories.FirstOrDefault(en => en.Id == e.Id);
            _db.Entry(f).CurrentValues.SetValues(e);
            return (_db.SaveChanges() > 0);
        }

        public List<Category> Get()
        {
            return _db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _db.Categories.FirstOrDefault(en => en.Id == id);
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
