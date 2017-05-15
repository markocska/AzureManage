using AzureManagementLib.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AzureManagementLib.Models;
using Microsoft.Practices.ServiceLocation;
using AzureManagementLib.ExtensionMethods;
using AzureManagementShared.ViewModel.Interfaces;
using System.Collections;
using AzureManagementShared.ViewModel.Services;

namespace AzureManagementShared.ViewModel
{
    public class AzureListViewModel<K> : ViewModelBase, IAzureListViewModel<K>
        where K : AzureViewModelBase
    {

        private readonly INavigationService _navigationService;
        private bool _isLoading = false;
        private RelayCommand _refreshCommand;
        private RelayCommand<K> _showDetailsCommand;
        private RelayCommand<K> _sortCommand;


        public ObservableCollection<K> Resources { get; private set; }

        public RelayCommand RefreshCommand => _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(
                        async () =>
                        {
                            Resources.Clear();
                            _isLoading = true;
                            RaisePropertyChanged(() => Resources);
                            try
                            {
                                var modelList = await ViewModelService.GetViewModelsAsync<K>();
                                Resources.AddRange(modelList);
                            }

                            catch (Exception ex)
                            {
                                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                                dialog.ShowError(ex, "Error when refreshing :-(", "OK", null);
                            }
                            RaisePropertyChanged(() => Resources);
                            _isLoading = false;
                        }
                        ));

        public RelayCommand<K> ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand
                    ?? (_showDetailsCommand = new RelayCommand<K>(
                        resource =>
                        {
                            if (!ShowDetailsCommand.CanExecute(resource))
                            {
                                return;
                            }

                            _navigationService.NavigateTo(
                                ViewModelLocator.SearchPageByType(
                                    typeof(K)), resource);
                        },
                        resource => resource != null));
            }
        }

        public RelayCommand SortCommand => _refreshCommand
                   ?? (_refreshCommand = new RelayCommand(
                       async () =>
                       {
                           Resources.Clear();
                           _isLoading = true;
                           RaisePropertyChanged(() => Resources);
                           try
                           {
                               var modelList = await ViewModelService.GetViewModelsAsync<K>();
                               Resources.AddRange(modelList);
                           }

                           catch (Exception ex)
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               dialog.ShowError(ex, "Error when refreshing :-(", "OK", null);
                           }
                           RaisePropertyChanged(() => Resources);
                           _isLoading = false;
                       }
                       ));




        public AzureListViewModel(
            INavigationService navigationService
            )
        {   

            _navigationService = navigationService;

            Resources = new ObservableCollection<K>();

        }


    }
}
