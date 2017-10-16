using System;
using System.Collections.Generic;
using System.Data.Entity;
using Test.BackEnd.TestDBContext;
using Test.Models.Entities;

namespace Test.BackEnd.Repositories
{
    public class FarmsRepository : IRepository<Farm>
    {
        private TestDBContext.TestDBContext db;

        public FarmsRepository(TestDBContext.TestDBContext context)
        {
            this.db = context;
        }

        public IEnumerable<Farm> GetAll()
        {
            return db.Farms;
        }

        public Farm Get(int id)
        {
            return db.Farms.Find(id);
        }

        public void Create(Farm entity)
        {
            db.Farms.Add(entity);
        }

        public void Update(Farm entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Farm entity = db.Farms.Find(id);
            if (entity != null)
                db.Farms.Remove(entity);
        }
    }
}