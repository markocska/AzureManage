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

namespace AzureManagementLib.Services
{
    public class AppServicePlanService : IAppServicePlanService
    {
        protected IAzure AuthenticatedAzure { get; private set; }

        IPagedCollection<IAppServicePlan> sqlServicePlans;

        public async Task<IList<IAppServicePlanModel>> GetResourcesAsync()
        {

            sqlServicePlans = await AuthenticatedAzure.AppServices.AppServicePlans.ListAsync();


           return sqlServicePlans.ConvertToList<IAppServicePlan,IAppServicePlanModel>(
                (IAppServicePlan plan) => { return new AppServicePlanModel(plan);
                });

        }

        public AppServicePlanService(IAzure azure)
        {
            this.AuthenticatedAzure = azure;
        }
    }
}
