using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class NewsRepo : IRepository<News, int>
    {
        NewsMSEntities db;

        public NewsRepo(NewsMSEntities db)
        {
            this.db = db;
        }
         
        public void Add(News e)
        {
            db.News.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var n = db.News.Find(id);
            db.News.Remove(n);
            db.SaveChanges();
        }

        public void Edit(News e)
        {
            var n = db.News.Find(e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }
    }
}
