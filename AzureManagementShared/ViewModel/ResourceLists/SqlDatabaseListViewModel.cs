using AzureManagementLib.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AzureManagementLib.Services;
using GalaSoft.MvvmLight.Views;

namespace AzureManagementShared.ViewModel.ResourceLists
{
    public class SqlDatabaseListViewModel : AzureListViewModel<ISqlDatabaseModel, SqlDatabaseViewModel>
    {
        public SqlDatabaseListViewModel(INavigationService navigationService, ISqlDatabaseService azureService)
            : base(navigationService, azureService, (ISqlDatabaseModel model) => new SqlDatabaseViewModel(model)) 
        {
        }
    }
}
