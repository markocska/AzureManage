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
using AzureManagementShared.ViewModel;
using AzureManagementLib.Models.Interfaces;

namespace AzureGui
{
    public class DatabaseResourceListActivity : ResourceListActivityBase<ISqlDatabaseModel,SqlDatabaseViewModel>
    {
        public AzureListViewModel<ISqlDatabaseModel, SqlDatabaseViewModel> ResourceListViewModel => ResourceListViewModel;

        protected async override void OnCreate(Bundle bundle)
        {
            
        }
    }
}