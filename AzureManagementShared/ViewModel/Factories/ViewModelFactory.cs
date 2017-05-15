using AzureManagementLib.Models;
using AzureManagementLib.Models.Interfaces;
using AzureManagementLib.Services.Factories;
using AzureManagementShared.ViewModel.Interfaces;
using AzureManagementShared.ViewModel.ResourceLists;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel.Factories
{
    public static class ViewModelFactory
    {

        private static MainViewModel _mainViewModel;
        private static SqlServerListViewModel _sqlServerListViewModel;
        private static SqlDatabaseListViewModel _sqlDatabaseListViewModel;
        private static AppServicePlanListViewModel _appServicePlanListViewModel;

        public static MainViewModel MainViewModel {
            get
            {
                return _mainViewModel
                    ?? (_mainViewModel = 
                    new MainViewModel(ServiceLocator.Current.GetInstance<INavigationService>()));

            }
        }

        public static SqlServerListViewModel SqlServerListViewModel
        {
            get
            {
                return _sqlServerListViewModel
                    ?? (_sqlServerListViewModel =
                    new SqlServerListViewModel(ServiceLocator.Current.GetInstance<INavigationService>()));
            }
        }

   

        public static AppServicePlanListViewModel AppServicePlanListViewModel
        {
            get
            {
                return _appServicePlanListViewModel
                    ?? (_appServicePlanListViewModel =
                    new AppServicePlanListViewModel(ServiceLocator.Current.GetInstance<INavigationService>()));
            }
        }

        public static SqlDatabaseListViewModel SqlDatabaseListViewModel
        {
            get
            {
                return _sqlDatabaseListViewModel
                    ?? (_sqlDatabaseListViewModel =
                    new SqlDatabaseListViewModel(ServiceLocator.Current.GetInstance<INavigationService>()));
            }
        }
    }
}
