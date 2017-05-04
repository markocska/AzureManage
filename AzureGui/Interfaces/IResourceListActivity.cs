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
using AzureManagementLib.Models;
using AzureManagementShared;
using AzureGui;
using AzureManagementShared.ViewModel;
using AzureGui.Helpers;
//using AzureManagementShared.ViewModel;
//using AzureManagementLib.Models;
//using AzureManagementShared;
//using AzureManagementLib.ModelView;

namespace AzureGui
{

    public interface IResourceListActivity<T,K> 
        where T : IAzureResource
        where K : AzureViewModelBase
    {
        AzureListViewModel<T, K> ResourceListViewModel
        {
            get;
        }
      
    }
}