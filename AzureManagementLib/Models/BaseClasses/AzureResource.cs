using AzureManagementLib.Services.Interfaces;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public class AzureResource<T> : IAzureResource
        where T : IHasName, IResource, IHasResourceGroup
    {
        T resource;
        IAzureAccInfo accInfo;

        public string Name => resource.Name;

        public string ResourceGroupName => resource.ResourceGroupName;

        public string Type => resource.Type;

        public string Region => resource.RegionName;

        public string TenantName => accInfo.TenantName;

        public string Subscription => accInfo.Subscription;

        public string Id => resource.Id;

        public AzureResource(T resource, IAzureAccInfo accInfo)
        {
            this.resource = resource;
            this.accInfo = accInfo;
        }
    }
}
