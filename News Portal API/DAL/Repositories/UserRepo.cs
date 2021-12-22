using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class UserRepo : IRepository<User, int>
    {
        NewsMSEntities db;

        public UserRepo(NewsMSEntities db)
        {
            this.db = db;
        }
        public void Add(User e)
        {
            db.Users.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var n = db.Users.Find(id);
            db.Users.Remove(n);
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var n = db.Users.Find(e.Id);
            db.Entry(n).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }
    }
}
