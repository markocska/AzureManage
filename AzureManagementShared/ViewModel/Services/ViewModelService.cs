using AzureManagementLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.ExtensionMethods;
using AzureManagementLib;

namespace AzureManagementShared.ViewModel.Services
{
    public static class ViewModelService
    {
        public static async Task<IList<K>> GetViewModelsAsync<K>()
           where K : AzureViewModelBase
        {
            if (typeof(K) == typeof(AppServicePlanViewModel))
            {
                var list = await  AppServicePlanService.GetResourcesAsync();

                IList<K> returnList = new List<K>();
                foreach(var item in list)
                {
                    returnList.Add(new AppServicePlanViewModel(item) as K);
                }
                return returnList;
            }
            else if (typeof(K) == typeof(SqlDatabaseViewModel)) 
            {
                var list = await SqlDatabaseService.GetResourcesAsync();

                IList<K> returnList = new List<K>();
                foreach (var item in list)
                {
                    returnList.Add(new SqlDatabaseViewModel(item) as K);
                }
                return returnList;
            }
            else if (typeof(K) == typeof(SqlServerViewModel))
            {
                var list = await SqlServerService.GetResourcesAsync();

                IList<K> returnList = new List<K>();
                foreach (var item in list)
                {
                    returnList.Add(new SqlServerViewModel(item) as K);
                }
                return returnList;
            }
            throw new Exception("Invalid View Model type");
        }
    }
}
