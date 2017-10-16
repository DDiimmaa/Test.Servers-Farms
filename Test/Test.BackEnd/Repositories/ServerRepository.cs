using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.BackEnd.TestDBContext;
using Test.Models.Entities;

namespace Test.BackEnd.Repositories
{
    public class ServerRepository : IRepository<Server>
    {
        private TestDBContext.TestDBContext db;

        public ServerRepository(TestDBContext.TestDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Server> GetAll()
        {
            return db.Servers;
        }

        public Server Get(int id)
        {
            return db.Servers.Find(id);
        }

        public void Create(Server entity)
        {
            db.Servers.Add(entity);
        }

        public void Update(Server entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Server entity = db.Servers.Find(id);
            if (entity != null)
                db.Servers.Remove(entity);
        }
    }
}