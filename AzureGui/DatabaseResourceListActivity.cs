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
using AzureManagementShared.ViewModel.ResourceLists;
using AzureManagementShared.ViewModel.Interfaces;
using GalaSoft.MvvmLight.Helpers;

namespace AzureGui
{
    [Activity]
    public class DatabaseResourceListActivity : ResourceListActivityBase<SqlDatabaseViewModel>
    {

        private SqlDatabaseListViewModel _databaseListViewModel;

        private SqlDatabaseListViewModel DatabaseListViewModel
        {
            get
            {
                return _databaseListViewModel
                    ?? (_databaseListViewModel = App.Locator.DatabasesViewModel
                );
            }
        }

        protected  override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Setup(DatabaseListViewModel);

            ResourceList.Adapter = DatabaseListViewModel.Resources.GetAdapter(GetDatabaseAdapter);

        }

        private View GetDatabaseAdapter(int position,SqlDatabaseViewModel model, View convertView)
        {
            convertView = LayoutInflater.Inflate(Resource.Layout.SqlDatabase, null);
            convertView.Visibility = model.IsHidden ? ViewStates.Invisible : ViewStates.Visible;

            var image = convertView.FindViewById<ImageView>(Resource.Id.sqlDatabaseImage);

            var name = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseName);
            name.Text = model.Name;

            var location = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseLocation);
            location.Text = model.Region;

            var resourceGroupName = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseResourceGroupName);
            resourceGroupName.Text = model.ResourceGroup;

            var isActive = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseIsActive);
            isActive.Text = model.Status;


            return convertView;
        }
    }
}