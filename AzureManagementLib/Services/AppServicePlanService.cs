using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.Models;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using AzureManagementLib.ExtensionMethods;
using AzureManagementLib.Models.Interfaces;
using AzureManagementLib.Services.Interfaces;

namespace AzureManagementLib.Services
{
    public static class AppServicePlanService  
    {
        private static IDictionary<string, IAzure> AuthenticatedAzureList { get; set; }

        private static IList<IAppServicePlanModel> sqlServicePlans = new List<IAppServicePlanModel>();

        public static async Task<IList<IAppServicePlanModel>> GetResourcesAsync()
        {

            AuthenticatedAzureList = AzureTenantContainer.LoggedInTenants;

            foreach (var azure in AuthenticatedAzureList)
            {
                
                var plans = await azure.Value.AppServices.AppServicePlans.ListAsync();

                sqlServicePlans.AddRange(
                    plans.ToList().ConvertToList<IAppServicePlan,IAppServicePlanModel>(
                        new AzureAccInfo(azure.Key,azure.Value.SubscriptionId),
                        (IAppServicePlan servicePlan,IAzureAccInfo accInfo) 
                            => { return new AppServicePlanModel(servicePlan, accInfo); }
                        )
                    );
            }

            return sqlServicePlans;

        }

    }
}
