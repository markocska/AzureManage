using System;
using System.Collections.Generic;
using System.Text;
using AzureManagementLib.Models;
using AzureManagementLib.Models.Interfaces;

namespace AzureManagementShared.ViewModel
{
    public class SqlDatabaseViewModel : AzureViewModelBase
    {
        ISqlDatabaseModel sqlDatabase;
        public SqlDatabaseViewModel(ISqlDatabaseModel sqlDatabase) 
            : base(sqlDatabase)
        {
            this.sqlDatabase = sqlDatabase;
        }

        public string Status {get { return sqlDatabase.Status; } }
    }
}
