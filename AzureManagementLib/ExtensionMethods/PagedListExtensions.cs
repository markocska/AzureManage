using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureManagementLib.ExtensionMethods;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using AzureManagementLib.Models;
using AzureManagementLib.Services.Interfaces;

namespace AzureManagementLib.ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static List<K> ConvertToList<T, K>(
            this IEnumerable<T> listToConvert,
            IAzureAccInfo accInfo,
            Func<T,IAzureAccInfo,K> converterFunc)
        {

            var list = new List<K>();
            foreach (var item in listToConvert)
            {
                list.Add(converterFunc(item,accInfo));
            }

            return list;
        }

        public static void AddRange<T>(this IList<T> list, IList<T> listToAdd)
        {
            if (list == null)
            {
                throw new ArgumentException("The value of list is null");
            }
            if (listToAdd == null)
            {
                throw new ArgumentException("The value of the list to add is 0");
            }

            foreach(var item in listToAdd)
            {
                list.Add(item);
            }
        }

        //public static void AddRange<T>(this IList<T> list, IReadOnlyList<T> listToAdd)
        //{
        //    if (list == null)
        //    {
        //        throw new ArgumentException("The value of list is null");
        //    }
        //    if (listToAdd == null)
        //    {
        //        throw new ArgumentException("The value of the list to add is 0");
        //    }

        //    foreach (var item in listToAdd)
        //    {
        //        list.Add(item);
        //    }
        //}

        public static IList<K> ConvertToList<T,K>(
            this IDictionary<IAzureAccInfo,IPagedCollection<T>> dict,
            Func<IAzureAccInfo,T,K> constructor)
        {
            var listToReturn = new List<K>();

            foreach(var keyValuePair in dict)
            {
                foreach (var item in keyValuePair.Value)
                {
                    listToReturn.Add(constructor(keyValuePair.Key, item));
                }
            }

            return listToReturn;
        }




    }
}
