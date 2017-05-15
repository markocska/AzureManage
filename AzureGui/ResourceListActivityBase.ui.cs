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
using AzureManagementLib.Models;
using AzureManagementShared;

namespace AzureGui
{
    public abstract partial class ResourceListActivityBase<K> : ActivityBaseEx
        where K : AzureViewModelBase
    {
        private AutoCompleteTextView _searchTextView;
        private Button _sortByButton;
        private Button _optionsButton;

        public ListView _resourceList;

        public ListView ResourceList
        {
            get
            {
                return _resourceList
                    ?? (_resourceList = FindViewById<ListView>(Resource.Id.resourceList));
            }
        }

        public Button SortByButton
        {
            get
            {
                return _sortByButton
                    ?? (_sortByButton = FindViewById<Button>(Resource.Id.sortButton));
            }
        }

        public Button OptionsButton
        {
            get
            {
                return _optionsButton
                    ?? (_optionsButton = FindViewById<Button>(Resource.Id.optionsButton));
            }
        }

        public AutoCompleteTextView SearchTextView
        {
            get
            {
               return _searchTextView
                    ?? (_searchTextView = FindViewById<AutoCompleteTextView>(Resource.Id.searchTextView));
            }
        }

    }
}