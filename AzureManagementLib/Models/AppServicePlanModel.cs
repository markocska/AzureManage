using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using AzureManagementLib.Models.Interfaces;

namespace AzureManagementLib.Models
{
    public class AppServicePlanModel : IAppServicePlanModel
    {
        private IAppServicePlan appServicePlan;

        public string Name => appServicePlan.Name;
        public string ResourceGroupName => appServicePlan.ResourceGroupName;

        public string Type => appServicePlan.Type;

        public string Region => appServicePlan.RegionName;

        public int NumberOfWebApps => appServicePlan.NumberOfWebApps;

        public AppServicePlanModel(IAppServicePlan appServicePlan) 
        {
            this.appServicePlan = appServicePlan;
        }

    }
}
