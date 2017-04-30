using AzureManagementLib.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Services
{
    public interface IAzureService<K> 
        where K : IAzureResource
    {
        Task<IList<K>> GetResourcesAsync();
    }
}
