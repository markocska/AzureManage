using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementShared.ViewModel.Services
{
    public static class SortingService
    {
        public enum AzureParams
        {
            Name, Type, Region, SubscriptionId,
            TenantId, Status, Version, NumberOfWebApps,
            ResourceGroup
        }

        public async static Task<IList<K>> Sort<K>(ObservableCollection<K> collection,
                                       AzureParams param)
            where K : AzureViewModelBase
        {
            return await Task.Run(() =>
           {
               List<K> sortedList = new List<K>(collection);

               switch (param)
               {
                   case AzureParams.Name:
                       sortedList.Sort((K a, K b) => { return a.Name.CompareTo(b.Name); });
                       break;
                   case AzureParams.Type:
                       sortedList.Sort((K a, K b) => { return a.Type.CompareTo(b.Type); });
                       break;
                   case AzureParams.Region:
                       sortedList.Sort((K a, K b) => { return a.Region.CompareTo(b.Region); });
                       break;
                   case AzureParams.ResourceGroup:
                       sortedList.Sort((K a, K b) => { return a.ResourceGroup.CompareTo(b.ResourceGroup); });
                       break;
                   default:
                       break;
               }

               return sortedList;
           }
            );
        }

    }
}
