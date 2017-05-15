using AzureManagementLib.Models;
using AzureManagementLib.Models.Interfaces;
using AzureManagementLib.Services.Interfaces;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public class SqlServerModel : AzureResource<ISqlServer>, ISqlServerModel
    {
        private ISqlServer sqlServer;

        internal SqlServerModel(ISqlServer sqlServer,
                                   IAzureAccInfo accInfo) :
            base(sqlServer,accInfo)
        {
            this.sqlServer = sqlServer;
           
        }

        public string Version => sqlServer.Version;
    }
}
