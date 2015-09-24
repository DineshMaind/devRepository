using MyDemoApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyDemoApp.Test
{
    public class FakeServiceFactory : IServiceFactory
    {
        private readonly IRepository _db = null;

        public FakeServiceFactory(IRepository db)
        {
            this._db = db;
        }

        public IRepository GetDatabaseObject()
        {
            return this._db;
        }
    }
}
