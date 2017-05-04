using AzureManagementLib.Models;
using AzureManagementLib.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel
{
    public class AppServicePlanViewModel : AzureViewModelBase
    {
        IAppServicePlanModel appServicePlanModel;

        public AppServicePlanViewModel(IAppServicePlanModel model) :
            base(model)
        {
            this.appServicePlanModel = model;
        }


    }
}
