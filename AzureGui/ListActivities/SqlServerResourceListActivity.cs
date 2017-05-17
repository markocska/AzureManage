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
using AzureManagementShared.ViewModel.ResourceLists;
using AzureManagementShared;
using GalaSoft.MvvmLight.Helpers;

namespace AzureGui.ListActivities
{   
    [Activity]
    public class SqlServerResourceListActivity : ResourceListActivityBase<SqlServerViewModel>
    {
        private SqlServerListViewModel _sqlServerListViewModel;

        private SqlServerListViewModel SqlServerListViewModel
        {
            get
            {
                return _sqlServerListViewModel
                    ?? (_sqlServerListViewModel = App.Locator.SqlServersViewModel
                );
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Setup(SqlServerListViewModel);

            //ResourceList.Adapter = SqlServerListViewModel.Resources.GetAdapter(GetSqlServerAdapter);

        }

        //private View GetSqlServerAdapter(int position, SqlServerViewModel model, View convertView)
        //{
        //    convertView = LayoutInflater.Inflate(Resource.Layout.SqlServer, null);
        //    convertView.Visibility = model.IsHidden ? ViewStates.Invisible : ViewStates.Visible;

        //    var image = convertView.FindViewById<ImageView>(Resource.Id.sqlDatabaseImage);

        //    var name = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseName);
        //    name.Text = model.Name;

        //    var location = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseLocation);
        //    location.Text = model.Region;

        //    var resourceGroupName = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseResourceGroupName);
        //    resourceGroupName.Text = model.ResourceGroup;

        //    var isActive = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseIsActive);
        //    isActive.Text = model.Status;

        //    var button = convertView.FindViewById<Button>(Resource.Id.sqlDatabaseActionButton);

        //    button.Click += (arg1, s) =>
        //    {
        //        PopupMenu menu = new PopupMenu(this, button);
        //        menu.Inflate(Resource.Layout.sqlDatabasePopupMenu);
        //        menu.Show();
        //    };


        //    return convertView;
        //}
    //}
}
}