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
    public class SqlDatabaseModel : AzureResource<ISqlDatabase>,ISqlDatabaseModel
    {
        private ISqlDatabase sqlDatabase;

        public string Status { get { return sqlDatabase.Status; } }

        internal SqlDatabaseModel(ISqlDatabase sqlDatabase, 
            IAzureAccInfo accInfo) :
            base(sqlDatabase,accInfo)
        {
            this.sqlDatabase = sqlDatabase;
        }
    }
}
