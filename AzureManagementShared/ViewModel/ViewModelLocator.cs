using AzureManagementLib;
using AzureManagementLib.Services;
using AzureManagementShared.ViewModel;
using GalaSoft.MvvmLight.Ioc;
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

        //private static readonly IDictionary<string, int> layouts = new Dictionary<string, int>
        //{
        //    {typeof() }
        //};

        public static readonly string sqlDatabaseListPageKey = "SqlDatabaseListPage";
        public static readonly string sqlDatabaseDetailsPageKey = "SqlDatabaseDetailsPage";

        public static readonly string sqlServerListPageKey = "SqlServerListPage";
        public static readonly string sqlServerDetailsPageKey = "SqlServerDetailsPage";

        public static readonly string appServicePlanListPageKey = "AppServicePlanListPage";
        public static readonly string appServicePlanDetailsPageKey = "AppServicePlanDetailsPage";


        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
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
            return pages.Values.Contains(page);
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ISqlServerService, SqlServerService>();
            SimpleIoc.Default.Register<ISqlDatabaseService, SqlDatabaseService>();
            SimpleIoc.Default.Register<IAppServicePlanService, AppServicePlanService>();

            SimpleIoc.Default.Register<MainViewModel>();


            pages = new Dictionary<string, string>
            {
                { typeof(SqlDatabaseViewModel).FullName,sqlDatabaseListPageKey },
                { typeof(SqlServerViewModel).FullName,sqlServerListPageKey}
            };
        }

    }
}
