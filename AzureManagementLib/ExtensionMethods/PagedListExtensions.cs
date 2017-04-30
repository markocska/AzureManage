using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.ExtensionMethods;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using AzureManagementLib.Models;

namespace AzureManagementLib.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static List<K> ConvertToList<T,K>(this IEnumerable<T> listToConvert,Func<T,K> converterFunc)
        {

            var list = new List<K>();
            foreach (var item in listToConvert)
            {
                list.Add(converterFunc(item));
            }

            return list;
        }
    }
}
