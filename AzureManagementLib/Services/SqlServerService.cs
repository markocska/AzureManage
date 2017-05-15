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
using AzureManagementLib.Services.Interfaces;

namespace AzureManagementLib
{

    public class SqlServerService     {
        private static IDictionary<string,IAzure> AuthenticatedAzureList { get; set; }

        private static IList<ISqlServerModel> sqlServers = new List<ISqlServerModel>();

       public static async Task<IList<ISqlServerModel>> GetResourcesAsync()
        {
            AuthenticatedAzureList = AzureTenantContainer.LoggedInTenants;
            sqlServers.Clear();

            foreach (var azure in AuthenticatedAzureList)
            {
                var list = await azure.Value.SqlServers.ListAsync();
                sqlServers.AddRange(
                    list.ConvertToList<ISqlServer,ISqlServerModel>(
                     new AzureAccInfo(azure.Key,azure.Value.SubscriptionId),
                    (ISqlServer server, IAzureAccInfo accInfo) => { return new SqlServerModel(server, accInfo); })
                    );
                
            }

            return sqlServers;
        }


    }
}
