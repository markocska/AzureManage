using AzureManagementLib.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AzureManagementLib.Services;
using GalaSoft.MvvmLight.Views;

namespace AzureManagementShared.ViewModel.ResourceLists
{
    public class SqlDatabaseListViewModel : AzureListViewModel<SqlDatabaseViewModel>
    {
        public SqlDatabaseListViewModel(INavigationService navigationService)
            : base(navigationService) 
        {
        }
    }
}
