﻿using System;
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
using AzureManagementLib.Models;
using AzureManagementShared;
using AzureGui.Helpers;
using AzureManagementShared.ViewModel.Interfaces;
using AzureManagementShared.ViewModel.Services;

namespace AzureGui
{
    public abstract partial class ResourceListActivityBase<K> : IResourceListActivity<K>
        where K : AzureViewModelBase
    {

        protected IAzureListViewModel<K> resourceListViewModel;


        protected void Setup(IAzureListViewModel<K> resourceListViewModel)
        {
            this.resourceListViewModel = resourceListViewModel;

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ResourceGroup);

            OptionsButton.Click += (s, args) =>
            {
                PopupMenu menu = new PopupMenu(this, OptionsButton);
                menu.Inflate(Resource.Layout.popupMenu);
                menu.Show();


                menu.MenuItemClick += (s1, arg1) =>
                {
                    resourceListViewModel.RefreshCommand.Execute(true);
                };
            };

            SortByButton.Click += (s, args) =>
            {
                PopupMenu menu = new PopupMenu(this, SortByButton);
                menu.Inflate(Resource.Layout.sortByMenu);
                menu.Show();

                menu.MenuItemClick += (s1, arg1) =>
                {
                    switch (arg1.Item.TitleFormatted.ToString())
                    {
                        case "Name":
                            resourceListViewModel
                            .SortByCommand
                            .Execute(SortingService.AzureParams.Name);
                            break;
                        case "Resource Group":
                            resourceListViewModel
                            .SortByCommand
                            .Execute(SortingService.AzureParams.ResourceGroup);
                            break;
                        case "Region":
                            resourceListViewModel
                           .SortByCommand
                           .Execute(SortingService.AzureParams.Region);
                            break;
                        case "Type":
                            resourceListViewModel
                           .SortByCommand
                           .Execute(SortingService.AzureParams.Type);
                            break;
                        default:
                            break;

                    }

                };
            };
        }

    }
}