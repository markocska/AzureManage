using AzureManagementLib.Models;
using AzureManagementLib.Models.Interfaces;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public class SqlServerModel : ISqlServerModel
    {
        private ISqlServer sqlServer;

        public string Name { get { return sqlServer.Name; } }

        public string ResourceGroupName { get { return sqlServer.ResourceGroupName; } }

        public string Type { get { return sqlServer.Type; } }

        public string Region { get { return sqlServer.RegionName; } }

        public string Version {get { return sqlServer.Version; } }

        internal SqlServerModel(ISqlServer sqlServer)
        {
            this.sqlServer = sqlServer;
        }

    }
}
