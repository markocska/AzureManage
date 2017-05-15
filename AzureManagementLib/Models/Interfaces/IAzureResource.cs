using AzureManagementLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Models
{
    public interface IAzureResource  : IAzureAccInfo
    {
        string Name { get;  }

        string ResourceGroupName { get;  }

        string Type { get;  }

        string Region { get;  }

        string Id { get; }


    }
}
