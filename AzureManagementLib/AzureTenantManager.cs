using AzureManagementLib.Services;
using AzureManagementLib.Services.Factories;
using Microsoft.Azure.Management.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace AzureManagementLib
{
    public class AzureTenantManager
    {
        public IAzure AuthenticatedAzure { get; private set; }

        public IAzureServiceFactory ServiceFactory { get; } 

        public void ChangeSubscription()
        {

        }

        public void ChangeTenant()
        {

        }
        
    }
}
