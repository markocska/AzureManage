using Android.App;
using AzureManagementLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private RelayCommand<string> _navigateToPage;
        private RelayCommand<PlatformParameters> _loginCommand;
        private RelayCommand<PlatformParameters> _logoutCommand;

        private AzureTenantManager resourceManager;

        public AzureTenantManager ResourceManager
        {
            get
            {
                return resourceManager;
            }
        }

        public RelayCommand<string> NavigateToPageCommand
        {
            get
            {
                return _navigateToPage
                    ?? ( _navigateToPage = new RelayCommand<string>(
                        (string page) =>
                        {
                            if (!NavigateToPageCommand.CanExecute(page))
                            {
                                return;
                            }
                            _navigationService.NavigateTo(page);
                        },
                        page => ViewModelLocator.PageExists(page)
                        ));
            }
        }
        
        public RelayCommand<PlatformParameters> LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand<PlatformParameters>(
                        async (PlatformParameters platformParams) =>
                        {
#if __ANDROID__

                             await AuthenticationManager.Authenticate(platformParams);
#endif
                        }
                        ));
            }
        }

        public MainViewModel(
            INavigationService navigationService)
        {
            this._navigationService = navigationService;
          //this.resourceManager = resourceManager;
        }
    }
}
