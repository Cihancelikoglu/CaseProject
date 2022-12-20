using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.DataAccess.Dapper.Abstract
{
    public interface IDbStrategy
    {
        IDbConnection GetConnection(string connectionString);
    }
}
