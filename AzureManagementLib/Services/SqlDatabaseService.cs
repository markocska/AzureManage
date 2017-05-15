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
using AzureManagementLib.Services.Interfaces;
using System.Collections;

namespace AzureManagementLib.Services
{
    public static class SqlDatabaseService 
    {
        private static IDictionary<string, IAzure> AuthenticatedAzureList { get; set; }

        private static List<ISqlDatabaseModel> sqlDatabases = new List<ISqlDatabaseModel>();

        public static async Task<IList<ISqlDatabaseModel>> GetResourcesAsync()
        {
            AuthenticatedAzureList = AzureTenantContainer.LoggedInTenants;


            await Task.Run(async () =>
                 {
                     sqlDatabases.Clear();
                     foreach (var azure in AuthenticatedAzureList)
                     {
                         var sqlServers =
                        await azure.Value.SqlServers.ListAsync();

                         IList<ISqlDatabase> databaseList;
                         foreach (var sqlServer in sqlServers)
                         {
                             databaseList = sqlServer.Databases.List().ToList();

                             sqlDatabases.AddRange(
                             databaseList.ConvertToList<ISqlDatabase, ISqlDatabaseModel>(
                                new AzureAccInfo(azure.Key, azure.Value.SubscriptionId),
                                (ISqlDatabase database, IAzureAccInfo accInfo) =>
                                {
                                    return new SqlDatabaseModel(database, accInfo);
                                }
                             )
                                 );

                         }

                     }
                 }
             );

            sqlDatabases = sqlDatabases.Distinct(new DatabaseComparer()).ToList();


            return sqlDatabases;

        }

        class DatabaseComparer : IEqualityComparer<ISqlDatabaseModel>
        {
            public bool Equals(ISqlDatabaseModel a, ISqlDatabaseModel b)
            {
                return a.Id == b.Id;
            }

            public int GetHashCode(ISqlDatabaseModel obj)
            {
                return obj.GetHashCode();
            }
        }


    }
}
