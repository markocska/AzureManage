using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.Models;
using AzureManagementLib.Services;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using AzureManagementLib.ExtensionMethods;
using AzureManagementLib.Models.Interfaces;

namespace AzureManagementLib
{

    public class SqlServerService : ISqlServerService
    {

        protected IAzure AuthenticatedAzure { get; private set; }

        IPagedCollection<ISqlServer> sqlServers;

        public SqlServerService(IAzure azure)
        {
            AuthenticatedAzure = azure;
        }


       public async Task<IList<ISqlServerModel>> GetResourcesAsync()
        {

            sqlServers = await AuthenticatedAzure.SqlServers.ListAsync();

            return sqlServers.ConvertToList<ISqlServer, ISqlServerModel>(
                (ISqlServer server) => { return new SqlServerModel(server); }
                );
        }


    }
}
