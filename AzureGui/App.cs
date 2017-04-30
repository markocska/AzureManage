using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using AzureManagementShared;
using AzureManagementLib.Models;
using AzureManagementShared.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace HelloAndroid
{
    public static class App
    {
        private static ViewModelLocator _locator;
        private static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    var nav = new NavigationService();
                    nav.Configure(
                            ViewModelLocator.sqlServerListPageKey,
                             typeof(ResourceListActivity<SqlServerModel, SqlServerViewModel>));
                    nav.Configure(
                            ViewModelLocator.sqlDatabaseListPageKey,
                            typeof(ResourceListActivity<SqlDatabaseModel, SqlDatabaseViewModel>));
                    nav.Configure(
                        ViewModelLocator.appServicePlanListPageKey,
                        typeof(ResourceListActivity<AppServicePlanModel,AppServicePlanViewModel>));

                    SimpleIoc.Default.Register<INavigationService>(() => nav);

                    _locator = new ViewModelLocator();
                }
                return _locator;
            }
        }
    }
}