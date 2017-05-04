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
using AzureGui.Helpers;

namespace AzureGui
{
    public partial class MainActivity : ActivityBaseEx
    {
        private Button _sqlDatabaseListButton;
        private Button _sqlServerListButton;
        private Button _appServicesListButton;

        public Button SqlDatabaseListButton
        {
            get
            {
                return _sqlDatabaseListButton
                    ?? (_sqlDatabaseListButton =
                    FindViewById<Button>(Resource.Id.sqlDatabaseListButton));
            }
        }

        public Button SqlServerListButton {
            get
            {
                return _sqlServerListButton
                    ?? (_sqlServerListButton =
                    FindViewById<Button>(Resource.Id.sqlServerListButton));
            }
        }

        public Button AppServicesListButton
        {
            get
            {
                return _appServicesListButton
                    ?? (_appServicesListButton =
                    FindViewById<Button>(Resource.Id.sqlServerListButton));
            }
        }
    }
}


