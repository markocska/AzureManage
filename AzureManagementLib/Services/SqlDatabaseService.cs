using AzureManagementLib.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.SqlServer.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.ExtensionMethods;
using AzureManagementLib.Models.Interfaces;

namespace AzureManagementLib.Services
{
    public class SqlDatabaseService : ISqlDatabaseService
    {
        protected IAzure AuthenticatedAzure { get; private set; }

        IReadOnlyList<ISqlDatabase> sqlDatabases;

        public SqlDatabaseService(IAzure azure)
        {
            AuthenticatedAzure = azure;
            sqlDatabases = new List<ISqlDatabase>();
        }

        public async Task<IList<ISqlDatabaseModel>> GetResourcesAsync()
        {

            var sqlServers =
             await AuthenticatedAzure.SqlServers.ListAsync(true);

  
            foreach (var sqlServer in sqlServers)
            {
                sqlDatabases.Concat<ISqlDatabase>(sqlServer.Databases.List());
            }

            return sqlDatabases.ConvertToList<ISqlDatabase, ISqlDatabaseModel>
                ((ISqlDatabase database) => { return new SqlDatabaseModel(database); });
            
        }
    }
}
