using AzureManagementLib.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Services
{
    public class SqlDatabaseService : ISqlDatabaseService
    {
        protected IAzure AuthenticatedAzure { get; private set; }

        List<ISqlDatabase> sqlDatabases;

        public SqlDatabaseService(IAzure azure)
        {
            AuthenticatedAzure = azure;
            sqlDatabases = new List<ISqlDatabase>();
        }


        public async Task<IList<SqlDatabaseModel>> GetResourcesAsync()
        {

            var sqlServers =
              await Task.Run(() => { return AuthenticatedAzure.SqlServers.List(); })
                  .ConfigureAwait(false);

            foreach(var server in sqlServers)
            {
                sqlDatabases.AddRange(server.Databases.List());
            }

            var returnList = new List<SqlDatabaseModel>();
            foreach (var sqlDatabase in sqlDatabases)
            {
                returnList.Add(new SqlDatabaseModel(sqlDatabase));
            }

            return returnList;
        }
    }
}
