using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.BackEnd.Repositories;

namespace Test.BackEnd.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private TestDBContext.TestDBContext db = new TestDBContext.TestDBContext();
        private FarmsRepository farmsRepository;
        private ServerRepository serversRepository;

        public FarmsRepository Farms
        {
            get
            {
                if (farmsRepository == null)
                    farmsRepository = new FarmsRepository(db);
                return farmsRepository;
            }
        }

        public ServerRepository Servers
        {
            get
            {
                if (serversRepository == null)
                    serversRepository = new ServerRepository(db);
                return serversRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}