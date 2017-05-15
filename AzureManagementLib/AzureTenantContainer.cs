using Microsoft.Azure.Management.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib
{
    public static class AzureTenantContainer
    {
        public static IDictionary<string, IAzure> LoggedInTenants { get; private set; } =
            new Dictionary<string, IAzure>();

        public static void RegistrateTenant(string tenantName,IAzure azure)
        {
            var login = new KeyValuePair<string, IAzure>(tenantName, azure);
            if (!LoggedInTenants.Contains(login))
            {
                LoggedInTenants.Add(login);
            }
        }

        public static void RemoveTenant(string tenantName,IAzure azure)
        {   
            LoggedInTenants.Remove(new KeyValuePair<string,IAzure>(tenantName,azure));
        }

        
    }
}
