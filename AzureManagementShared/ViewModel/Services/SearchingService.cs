using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementShared.ViewModel.Services
{
    public static class SearchingService
    {

        public static async Task<List<K>> Search<K>(ObservableCollection<K> source,
                                                string searchParam)
            where K : AzureViewModelBase
        {
            return await Task.Run(() =>
          {
              foreach (var item in source)
              {
                  if (!item.Name.Contains(searchParam)
                      && !item.Region.Contains(searchParam)
                      && !item.ResourceGroup.Contains(searchParam)
                      && !item.Type.Contains(searchParam)
                      )
                  {
                      item.IsHidden = true;
                  }
                  else
                  {
                      item.IsHidden = false;
                  }
              }
              var list = new List<K>(source);
              list.Sort((K a, K b) => { return a.IsHidden.CompareTo(b.IsHidden); });
              return list;
          }
            );
        }
    }
}
