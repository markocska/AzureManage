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

            convertView = base.GetResourceAdapter(position, model, convertView);

            var image = convertView.FindViewById<ImageView>(Resource.Id.resourceImage);
            image.SetImageResource(Resource.Drawable.sqlDatabase);

            var location = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseLocation);
            location.Text = model.Region;

            var isActive = convertView.FindViewById<TextView>(Resource.Id.sqlDatabaseIsActive);
            isActive.Text = model.Status;

            var dbActionButton = convertView.FindViewById<Button>(Resource.Id.resourceActionButton);

            dbActionButton.Click += (arg1, s) =>
            {                
                    PopupMenu menu = new PopupMenu(this, dbActionButton);
                    menu.Inflate(Resource.Layout.databasePopupMenu);
                menu.Inflate(Resource.Layout.resourcePopupMenu);

                menu = base.RegisterQuickActions(menu);

                menu.MenuItemClick += (d, arg) =>
                {
                    if (arg.Item.ItemId == Resource.Id.action_test)
                    {
                        return;
                    }
                };
                menu.Show();

            };

            return convertView;
        }
    }
}