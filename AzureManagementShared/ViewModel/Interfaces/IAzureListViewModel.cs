using AzureManagementShared.ViewModel.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel.Interfaces
{
    public interface IAzureListViewModel<K>
        where K : AzureViewModelBase
    {
        RelayCommand RefreshCommand
        {
            get;
        }

        RelayCommand<K> ShowDetailsCommand
        {
            get;
        }

        RelayCommand<SortingService.AzureParams> SortByCommand
        {
            get;
        }

        RelayCommand<string> SearchCommand
        {
            get;
        }
    }
}
