using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class CommentRepo : IRepository<Comment, int>
    {
        NewsMSEntities db;

        public CommentRepo(NewsMSEntities db)
        {
            this.db = db;
        }
        public void Add(Comment e)
        {
            db.Comments.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var n = db.Comments.Find(id);
            db.Comments.Remove(n);
            db.SaveChanges();
        }

        public void Edit(Comment e)
        {
            var n = db.Comments.Find(e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Comment> Get()
        {
            return db.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }
    }
}

