using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models.Interfaces
{
    public interface IAppServicePlanModel : IAzureResource
    {
        int NumberOfWebApps { get; }
    }
}
