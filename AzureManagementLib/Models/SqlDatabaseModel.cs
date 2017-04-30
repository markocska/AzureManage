using AzureManagementLib.Models.Interfaces;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public class SqlDatabaseModel : ISqlDatabaseModel
    {
        private ISqlDatabase sqlDatabase;

        public string Name => sqlDatabase.Name;

        public string ResourceGroupName => sqlDatabase.ResourceGroupName;

        public string Type => sqlDatabase.Type;

        public string Region => sqlDatabase.RegionName;

        public string Status { get { return sqlDatabase.Status; } }

        internal SqlDatabaseModel(ISqlDatabase sqlDatabase)
        {
            this.sqlDatabase = sqlDatabase;
        }
    }
}
