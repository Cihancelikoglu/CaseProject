using CaseProject.Core.DataAccess.Dapper.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.DataAccess.Dapper.Context
{
    public class DbContext
    {
        private IDbStrategy _dbStrategy;

        public DbContext SetStrategy()
        {
            _dbStrategy = new SqlServerStrategy();
            return this;
        }

        public IDbConnection GetDbContext(string connectionString)
        {
            return _dbStrategy.GetConnection(connectionString);
        }
    }
}
