using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using AzureManagementLib.Models.Interfaces;
using AzureManagementLib.Services.Interfaces;

namespace AzureManagementLib.Models
{
    public class AppServicePlanModel : AzureResource<IAppServicePlan>, IAppServicePlanModel
    {
        private IAppServicePlan appServicePlan;

        public int NumberOfWebApps => appServicePlan.NumberOfWebApps;

        public AppServicePlanModel(IAppServicePlan appServicePlan,
                                    IAzureAccInfo accInfo) :
            base(appServicePlan,accInfo)
        {
            this.appServicePlan = appServicePlan;
        }

    }
}
