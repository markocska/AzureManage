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
using AzureManagementShared.ViewModel.ResourceConstructor;
using AzureManagementLib.ExtensionMethods;

namespace AzureManagementShared.ViewModel
{
    public class AzureListViewModel<T,K> : ViewModelBase
        where T : IAzureResource
        where K : AzureViewModelBase
    {

        private readonly IAzureService<T> _azureService;
        private readonly INavigationService _navigationService;
        private bool _isLoading=false;
        private RelayCommand _refreshCommand;
        private RelayCommand<K> _showDetailsCommand;

        Func<T, K> viewModelConstructor;


        public ObservableCollection<K> Resources { get; private set; }

        public RelayCommand RefreshCommand { 
            get
            {
                return _refreshCommand
                    ?? (_refreshCommand = new RelayCommand(
                        async () =>
                        {
                            Resources.Clear();
                            _isLoading = true;

                            try
                            {
                                var modelList = await _azureService.GetResourcesAsync();

                                Resources= new ObservableCollection<K>(
                                    modelList.ConvertToList<T, K>(viewModelConstructor)
                                    );
                            }
                            catch (Exception ex)
                            {
                                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                                dialog.ShowError(ex, "Error when refreshing :-(", "OK", null);
                            }
                            RaisePropertyChanged("Resources");
                            _isLoading = false;
                        }
                        ));
            }
        }

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
                                    typeof(K)),resource);
                        },
                        resource => resource != null));
            }
        }



        public AzureListViewModel(
            INavigationService navigationService,
            IAzureService<T> azureService,
            Func<T,K> viewModelConstructor
            ) 
        {
            _azureService = azureService;
            _navigationService = navigationService;
            this.viewModelConstructor = viewModelConstructor;

            Resources = new ObservableCollection<K>();

        }


    }
}
