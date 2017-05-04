using AzureManagementLib.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AzureManagementLib.Services;
using GalaSoft.MvvmLight.Views;

namespace AzureManagementShared.ViewModel.ResourceLists
{
    public class AppServicePlanListViewModel : AzureListViewModel<IAppServicePlanModel, AppServicePlanViewModel>
    {
        public AppServicePlanListViewModel(INavigationService navigationService, IAppServicePlanService azureService) 
            : base(navigationService, azureService, (IAppServicePlanModel model) => new AppServicePlanViewModel(model))
        {

        }
    }
}
