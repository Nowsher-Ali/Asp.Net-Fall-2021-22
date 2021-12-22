using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ReactRepo : IRepository<React, int>
    {
        NewsMSEntities db;

        public ReactRepo(NewsMSEntities db)
        {
            this.db = db;
        }
        public void Add(React e)
        {
            db.Reacts.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var n = db.Reacts.Find(id);
            db.Reacts.Remove(n);
            db.SaveChanges();
        }

        public void Edit(React e)
        {
            var n = db.Reacts.Find(e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<React> Get()
        {
            return db.Reacts.ToList();
        }

        public React Get(int id)
        {
            return db.Reacts.Find(id);
        }
    }
}
