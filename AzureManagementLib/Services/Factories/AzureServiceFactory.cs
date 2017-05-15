using Microsoft.Azure.Management.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Services.Factories
{
    public class AzureServiceFactory 
    {

        IAzure authenticatedAzure;

   

        public AzureServiceFactory(IAzure authenticatedAzure)
        {
            this.authenticatedAzure = authenticatedAzure;
        }
    }
}
