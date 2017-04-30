using AzureManagementLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel
{
    public class AppServicePlanViewModel : AzureViewModelBase
    {
        AppServicePlanModel appServicePlanModel;

        public AppServicePlanViewModel(AppServicePlanModel model) :
            base(model)
        {
            this.appServicePlanModel = model;
        }


    }
}
