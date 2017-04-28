using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.Models;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Fluent;

namespace AzureManagementLib.Services
{
    public class AppServicePlanService : IAppServicePlanService
    {
        protected IAzure AuthenticatedAzure { get; private set; }

        PagedList<IAppServicePlan> sqlServicePlans;

        public Task<IList<AppServicePlanModel>> GetResourcesAsync()
        {
            var returnList = new List<AppServicePlanModel>();

            sqlServicePlans =
              await Task.Run(() => { return AuthenticatedAzure.AppServices.AppServicePlans.; })
                  .ConfigureAwait(false);

            foreach (var sqlServer in sqlServers)
            {
                returnList.Add(new SqlServerModel(sqlServer));
            }

            return returnList;
        }

        public AppServicePlanService(IAzure azure)
        {
            this.AuthenticatedAzure = azure;
        }
    }
}
