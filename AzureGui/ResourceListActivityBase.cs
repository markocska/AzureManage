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
using AzureManagementLib.Models;
using AzureManagementShared;
using AzureGui.Helpers;

namespace AzureGui
{
    public partial class ResourceListActivityBase<T, K> : ActivityBaseEx, IResourceListActivity<T, K>
        where T : IAzureResource
        where K : AzureViewModelBase
    {
        public AzureListViewModel<T, K> ResourceListViewModel { get;  }

        
    }
}