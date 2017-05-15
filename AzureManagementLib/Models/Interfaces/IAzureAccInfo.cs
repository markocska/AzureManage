using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Services.Interfaces
{
    public interface IAzureAccInfo
    {
        string TenantName { get;  }

        string Subscription { get;  }
    }
}
