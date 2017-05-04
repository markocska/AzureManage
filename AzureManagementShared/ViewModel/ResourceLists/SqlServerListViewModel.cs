using AzureManagementLib.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AzureManagementLib.Services;
using GalaSoft.MvvmLight.Views;

namespace AzureManagementShared.ViewModel.ResourceLists
{
    public class SqlServerListViewModel : AzureListViewModel<ISqlServerModel, SqlServerViewModel>
    {
        public SqlServerListViewModel(INavigationService navigationService, ISqlServerService azureService) 
            : base(navigationService, azureService,(ISqlServerModel model) => new SqlServerViewModel(model))
        {
           
        }


      
    }
}
