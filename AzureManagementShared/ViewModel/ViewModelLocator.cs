using AzureManagementLib;
using AzureManagementLib.Services;
using AzureManagementShared.ViewModel;
using AzureManagementShared.ViewModel.Factories;
using AzureManagementShared.ViewModel.ResourceLists;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared
{
    public class ViewModelLocator
    {

        private static readonly IDictionary<string, string> pages = new Dictionary<string, string>
            {
                { typeof(SqlDatabaseViewModel).FullName,sqlDatabaseListPageKey },
                { typeof(SqlServerViewModel).FullName,sqlServerListPageKey}
            };

  

        public static readonly string sqlDatabaseListPageKey = "SqlDatabaseListPage";
        public static readonly string sqlDatabaseDetailsPageKey = "SqlDatabaseDetailsPage";

        public static readonly string sqlServerListPageKey = "SqlServerListPage";
        public static readonly string sqlServerDetailsPageKey = "SqlServerDetailsPage";

        public static readonly string appServicePlanListPageKey = "AppServicePlanListPage";
        public static readonly string appServicePlanDetailsPageKey = "AppServicePlanDetailsPage";


        public MainViewModel MVM
        {
            get
            {
                return ViewModelFactory.MainViewModel;
            }
        }

        public SqlDatabaseListViewModel DatabasesViewModel
        {
            get
            {
                return ViewModelFactory.SqlDatabaseListViewModel;
            }
        }

        public SqlServerListViewModel SqlServersViewModel
        {
            get
            {
                return ViewModelFactory.SqlServerListViewModel;
            }
        }

        public AppServicePlanListViewModel AppServicePlansViewModel
        {
            get
            {
                return ViewModelFactory.AppServicePlanListViewModel;
            }
        }

        public static string SearchPageByType(Type type)
        {
            return pages[type.FullName];
        }

        public static string SearchPage(string pageName)
        {
            return pages[pageName];
        }

        public static bool PageExists(string page)
        {
            return true;
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            pages = new Dictionary<string, string>
            {
                { typeof(SqlDatabaseViewModel).FullName,sqlDatabaseListPageKey },
                { typeof(SqlServerViewModel).FullName,sqlServerListPageKey}
            };
        }

    }
}
