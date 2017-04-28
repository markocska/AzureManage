using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;

namespace AzureManagementLib.Models
{
    public class AppServicePlanModel : AzureResource<IAppServicePlan>
    {
        private IAppServicePlan appServicePlan;
        public AppServicePlanModel(IAppServicePlan appServicePlan) : base(appServicePlan)
        {
            this.appServicePlan = appServicePlan;
        }
        public int NumberOfWebApps { get { return appServicePlan.NumberOfWebApps; } }

    }
}
