using AzureManagementLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public class AzureAccInfo : IAzureAccInfo
    {   

        public AzureAccInfo(string tenantName, string subscription )
        {
            TenantName = tenantName;
            Subscription = subscription;
        }

        public string TenantName  { get; }

        public string Subscription { get;  }
    }
}
