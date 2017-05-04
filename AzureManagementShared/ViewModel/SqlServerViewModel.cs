//using AzureManagementLib.ModelView;
using AzureManagementLib.Models;
using AzureManagementLib.Models.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared
{
    public class SqlServerViewModel : AzureViewModelBase
    {
        ISqlServerModel sqlServer;

        public SqlServerViewModel(ISqlServerModel sqlServerModel)
            :base(sqlServerModel)
        {
            sqlServer = sqlServerModel;
        }

       public string Version { get { return sqlServer.Version; } }
       
        public static SqlServerViewModel Create(ISqlServerModel model)
        {
            return new SqlServerViewModel(model);
        }
    }
}

